#
#   eduVPN - End-user friendly VPN
#
#   Copyright: 2017, The Commons Conservancy eduVPN Programme
#   SPDX-License-Identifier: GPL-3.0+
#

!INCLUDE "BuildStrings.mak"

SETUP_TARGET=$(PLAT)
!IF "$(CFG)" == "Debug"
SETUP_TARGET=$(SETUP_TARGET)D
!ENDIF

# WiX parameters
WIX_CANDLE_FLAGS_LOCAL=$(WIX_CANDLE_FLAGS) -arch $(PLAT) -deduVPN.TargetDir="bin\$(CFG)\$(PLAT)\\" -deduVPN.VersionInformational="$(PRODUCT_VERSION_STR) $(SETUP_TARGET)"
!IF "$(PLAT)" == "x64"
WIX_CANDLE_FLAGS_LOCAL=$(WIX_CANDLE_FLAGS_LOCAL) -deduVPN.ProgramFilesFolder="ProgramFiles64Folder"
!ELSE
WIX_CANDLE_FLAGS_LOCAL=$(WIX_CANDLE_FLAGS_LOCAL) -deduVPN.ProgramFilesFolder="ProgramFilesFolder"
!ENDIF

!IF "$(CFG)" == "Debug"
VC150REDIST_MSM=Microsoft_VC150_DebugCRT_$(PLAT).msm
!ELSE
VC150REDIST_MSM=Microsoft_VC150_CRT_$(PLAT).msm
!ENDIF


Clean ::
	-devenv.com "eduVPN.sln" /Clean "$(CFG)|$(PLAT)" $(DEVENV_FLAGS)


######################################################################
# Setup
######################################################################

!IF "$(CFG)" == "Release"
SetupBuild ::
	devenv.com "eduVPN.sln" /Build "$(CFG)|$(PLAT)" $(DEVENV_FLAGS)

SetupMSI :: \
	"$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(SETUP_TARGET).msi"
!ENDIF


######################################################################
# Building
######################################################################

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPN.Client.exe" ::
	devenv.com "eduVPN.sln" /Build "$(CFG)|$(PLAT)" $(DEVENV_FLAGS)

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\$(VC150REDIST_MSM)" : "$(VCINSTALLDIR)Redist\MSVC\14.10.25008\MergeModules\$(VC150REDIST_MSM)"
	copy /y $** $@ > NUL

Clean ::
	-if exist "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\$(VC150REDIST_MSM)" del /f /q "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\$(VC150REDIST_MSM)"

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPNClient.wixobj" : \
	"eduVPNClient.wxs" \
	"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\$(VC150REDIST_MSM)"
	"$(WIX)bin\wixcop.exe" $(WIX_WIXCOP_FLAGS) "eduVPNClient.wxs"
	"$(WIX)bin\candle.exe" $(WIX_CANDLE_FLAGS_LOCAL) "-deduVPN.VC150RedistMSM=$(VC150REDIST_MSM)" -out $@ "eduVPNClient.wxs"

Clean ::
	-if exist "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPNClient.wixobj" del /f /q "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPNClient.wixobj"

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduEd25519.dll.wixobj" : "eduEd25519\eduEd25519\eduEd25519.wxs"
	"$(WIX)bin\wixcop.exe" $(WIX_WIXCOP_FLAGS) $**
	"$(WIX)bin\candle.exe" $(WIX_CANDLE_FLAGS_LOCAL) -out $@ $**

Clean ::
	-if exist "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduEd25519.dll.wixobj" del /f /q "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduEd25519.dll.wixobj"

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduJSON.dll.wixobj" : "eduJSON\eduJSON\eduJSON.wxs"
	"$(WIX)bin\wixcop.exe" $(WIX_WIXCOP_FLAGS) $**
	"$(WIX)bin\candle.exe" $(WIX_CANDLE_FLAGS_LOCAL) -out $@ $**

Clean ::
	-if exist "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduJSON.dll.wixobj" del /f /q "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduJSON.dll.wixobj"

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduOAuth.dll.wixobj" : "eduOAuth\eduOAuth\eduOAuth.wxs"
	"$(WIX)bin\wixcop.exe" $(WIX_WIXCOP_FLAGS) $**
	"$(WIX)bin\candle.exe" $(WIX_CANDLE_FLAGS_LOCAL) -out $@ $**

Clean ::
	-if exist "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduOAuth.dll.wixobj" del /f /q "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduOAuth.dll.wixobj"

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduOpenVPN.dll.wixobj" : "eduOpenVPN\eduOpenVPN\eduOpenVPN.wxs"
	"$(WIX)bin\wixcop.exe" $(WIX_WIXCOP_FLAGS) $**
	"$(WIX)bin\candle.exe" $(WIX_CANDLE_FLAGS_LOCAL) -out $@ $**

Clean ::
	-if exist "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduOpenVPN.dll.wixobj" del /f /q "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduOpenVPN.dll.wixobj"

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPN.dll.wixobj" : "eduVPN\eduVPN.wxs"
	"$(WIX)bin\wixcop.exe" $(WIX_WIXCOP_FLAGS) $**
	"$(WIX)bin\candle.exe" $(WIX_CANDLE_FLAGS_LOCAL) -out $@ $**

Clean ::
	-if exist "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPN.dll.wixobj" del /f /q "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPN.dll.wixobj"

"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPN.Client.exe.wixobj" : "eduVPN.Client\eduVPN.Client.wxs"
	"$(WIX)bin\wixcop.exe" $(WIX_WIXCOP_FLAGS) $**
	"$(WIX)bin\candle.exe" $(WIX_CANDLE_FLAGS_LOCAL) -out $@ $**

Clean ::
	-if exist "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPN.Client.exe.wixobj" del /f /q "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\eduVPN.Client.exe.wixobj"

"$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(SETUP_TARGET).msi" : \
	"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(SETUP_TARGET)_sl.mst" \
	"$(OUTPUT_DIR)\$(CFG)\$(PLAT)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(SETUP_TARGET)_en-US.msi"
	-if exist $@ del /f /q $@
	-if exist "$(@:"=).tmp" del /f /q "$(@:"=).tmp"
	copy /y "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(SETUP_TARGET)_en-US.msi" "$(@:"=).tmp" > NUL
	cscript.exe $(CSCRIPT_FLAGS) "bin\MSI.wsf" //Job:AddStorage "$(@:"=).tmp" "$(OUTPUT_DIR)\$(CFG)\$(PLAT)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(SETUP_TARGET)_sl.mst" 1060 /L
!IFDEF MANIFESTCERTIFICATETHUMBPRINT
	signtool.exe sign /sha1 "$(MANIFESTCERTIFICATETHUMBPRINT)" /t "$(MANIFESTTIMESTAMPURL)" /d "$(SIGNTOOL_DESC)" /q "$(@:"=).tmp"
!ENDIF
	move /y "$(@:"=).tmp" $@ > NUL

Clean ::
	-if exist "$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(SETUP_TARGET).msi" del /f /q "$(SETUP_DIR)\$(SETUP_NAME)_$(PRODUCT_VERSION_STR)_$(SETUP_TARGET).msi"


######################################################################
# Locale-specific rules
######################################################################

LANG=en-US
!INCLUDE "BuildCfgPlatLang.mak"

LANG=sl
!INCLUDE "BuildCfgPlatLang.mak"
