﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SunfrogUploader.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\DataConfig\\Sunfrog\\acc.json")]
        public string SunfrogConfig {
            get {
                return ((string)(this["SunfrogConfig"]));
            }
            set {
                this["SunfrogConfig"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\DataConfig\\Logo\\{0}.json")]
        public string LogoConfig {
            get {
                return ((string)(this["LogoConfig"]));
            }
            set {
                this["LogoConfig"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\DataConfig\\Content\\{0}.json")]
        public string ContentConfig {
            get {
                return ((string)(this["ContentConfig"]));
            }
            set {
                this["ContentConfig"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\Resources\\Logo\\")]
        public string LogoPath {
            get {
                return ((string)(this["LogoPath"]));
            }
            set {
                this["LogoPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-_-")]
        public string SplitString {
            get {
                return ((string)(this["SplitString"]));
            }
            set {
                this["SplitString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\Resources\\Autologo\\")]
        public string LogoExportPath {
            get {
                return ((string)(this["LogoExportPath"]));
            }
            set {
                this["LogoExportPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("_")]
        public string ExportSplitString {
            get {
                return ((string)(this["ExportSplitString"]));
            }
            set {
                this["ExportSplitString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\ListNameSuccess.txt")]
        public string ListNameSuccess {
            get {
                return ((string)(this["ListNameSuccess"]));
            }
            set {
                this["ListNameSuccess"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\ErrorName.txt")]
        public string ErrorNameList {
            get {
                return ((string)(this["ErrorNameList"]));
            }
            set {
                this["ErrorNameList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\uploaded.txt")]
        public string UploadedLinks {
            get {
                return ((string)(this["UploadedLinks"]));
            }
            set {
                this["UploadedLinks"] = value;
            }
        }
    }
}
