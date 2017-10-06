#
#   eduVPN - End-user friendly VPN
#
#   Copyright: 2017, The Commons Conservancy eduVPN Programme
#   SPDX-License-Identifier: GPL-3.0+
#

!IF "$(LANG)" == "en-US"
!INCLUDE "BuildStrings.mak"
WIX_LOC_FILE=eduVPN.wxl
!ELSE
!INCLUDE "BuildStrings.$(LANG).mak"
WIX_LOC_FILE=eduVPN.$(LANG).wxl
!ENDIF


######################################################################
# Setup
######################################################################

SetupExe :: \
	"$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe"


######################################################################
# Building
######################################################################

"$(OUTPUT_DIR)\Release\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe" : \
	"$(OUTPUT_DIR)\Release\eduVPN.wixobj" \
	"$(OUTPUT_DIR)\Release\OpenVPN.wixobj" \
	"$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_x86.msi" \
	"$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_x64.msi"
	"$(WIX)bin\light.exe" $(WIX_LIGHT_FLAGS) -cultures:$(LANG) -loc "$(WIX_LOC_FILE)" -out $@ "$(OUTPUT_DIR)\Release\eduVPN.wixobj" "$(OUTPUT_DIR)\Release\OpenVPN.wixobj"

Clean ::
	-if exist "$(OUTPUT_DIR)\Release\$(SETUP_NAME)_*_$(LANG).exe" del /f /q "$(OUTPUT_DIR)\Release\$(SETUP_NAME)_*_$(LANG).exe"

!IFDEF MANIFESTCERTIFICATETHUMBPRINT
"$(OUTPUT_DIR)\Release\x86\Engine_$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe" : "$(OUTPUT_DIR)\Release\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe"
	-if exist "$(@:"=).tmp" del /f /q "$(@:"=).tmp"
	"$(WIX)bin\insignia.exe" $(WIX_INSIGNIA_FLAGS) -ib $** -o "$(@:"=).tmp"
	signtool.exe sign /sha1 "$(MANIFESTCERTIFICATETHUMBPRINT)" /fd sha256 /as /tr "$(MANIFESTTIMESTAMPRFC3161URL)" /d "$(SIGNTOOL_DESC)" /q "$(@:"=).tmp"
	move /y "$(@:"=).tmp" $@ > NUL

Clean ::
	-if exist "$(OUTPUT_DIR)\Release\x86\Engine_$(SETUP_NAME)_*_$(LANG).exe" del /f /q "$(OUTPUT_DIR)\Release\x86\Engine_$(SETUP_NAME)_*_$(LANG).exe"

"$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe" : \
	"$(OUTPUT_DIR)\Release\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe" \
	"$(OUTPUT_DIR)\Release\x86\Engine_$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe"
	-if exist "$(@:"=).tmp" del /f /q "$(@:"=).tmp"
	"$(WIX)bin\insignia.exe" $(WIX_INSIGNIA_FLAGS) -ab "$(OUTPUT_DIR)\Release\x86\Engine_$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe" "$(OUTPUT_DIR)\Release\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe" -o "$(@:"=).tmp"
	signtool.exe sign /sha1 "$(MANIFESTCERTIFICATETHUMBPRINT)" /fd sha256 /as /tr "$(MANIFESTTIMESTAMPRFC3161URL)" /d "$(SIGNTOOL_DESC)" /q "$(@:"=).tmp"
	move /y "$(@:"=).tmp" $@ > NUL
!ELSE
"$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe" : "$(OUTPUT_DIR)\Release\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe"
	copy /y $** $@ > NUL
!ENDIF

Clean ::
	-if exist "$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe" del /f /q "$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(LANG).exe"
