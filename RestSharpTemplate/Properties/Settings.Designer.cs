﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestSharpTemplate.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("RestSharpTemplate")]
        public string REPORT_NAME {
            get {
                return ((string)(this["REPORT_NAME"]));
            }
            set {
                this["REPORT_NAME"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("29")]
        public int REPORT_SUBSTRING_LENGTH {
            get {
                return ((int)(this["REPORT_SUBSTRING_LENGTH"]));
            }
            set {
                this["REPORT_SUBSTRING_LENGTH"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public string DB_CONNECTION_TIMEOUT {
            get {
                return ((string)(this["DB_CONNECTION_TIMEOUT"]));
            }
            set {
                this["DB_CONNECTION_TIMEOUT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("usuarioAuthentication")]
        public string AUTHENTICATOR_USER {
            get {
                return ((string)(this["AUTHENTICATOR_USER"]));
            }
            set {
                this["AUTHENTICATOR_USER"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("senhaAuthentication")]
        public string AUTHENTICATOR_PASSWORD {
            get {
                return ((string)(this["AUTHENTICATOR_PASSWORD"]));
            }
            set {
                this["AUTHENTICATOR_PASSWORD"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.168.99.100:8989")]
        public string URL {
            get {
                return ((string)(this["URL"]));
            }
            set {
                this["URL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("aGU5l_OqRxM-bv-B2oQ3zV1oxyAXrCNr")]
        public string TOKEN {
            get {
                return ((string)(this["TOKEN"]));
            }
            set {
                this["TOKEN"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3306")]
        public string DB_PORT {
            get {
                return ((string)(this["DB_PORT"]));
            }
            set {
                this["DB_PORT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.99.100")]
        public string DB_URL {
            get {
                return ((string)(this["DB_URL"]));
            }
            set {
                this["DB_URL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("bugtracker")]
        public string DB_NAME {
            get {
                return ((string)(this["DB_NAME"]));
            }
            set {
                this["DB_NAME"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("root")]
        public string DB_USER {
            get {
                return ((string)(this["DB_USER"]));
            }
            set {
                this["DB_USER"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("root")]
        public string DB_PASSWORD {
            get {
                return ((string)(this["DB_PASSWORD"]));
            }
            set {
                this["DB_PASSWORD"] = value;
            }
        }
    }
}
