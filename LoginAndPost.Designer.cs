﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeleniumingIT {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
    internal sealed partial class LoginAndPost : global::System.Configuration.ApplicationSettingsBase {
        
        private static LoginAndPost defaultInstance = ((LoginAndPost)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new LoginAndPost())));
        
        public static LoginAndPost Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tomerezon@gmail.com")]
        public string correctEmail {
            get {
                return ((string)(this["correctEmail"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("vpugk,ktchc")]
        public string correctPass {
            get {
                return ((string)(this["correctPass"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\\\Users\\\\Tomer\\\\Desktop\\\\Was.txt")]
        public string correctPath {
            get {
                return ((string)(this["correctPath"]));
            }
        }
    }
}
