﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RemoteDataAccessor.WindowsServiceEngine.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RemoteDataAccessor.WindowsServiceEngine.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DataAccessProxy {0} is reinitialization by dataAccessProxy {1} two dataAccessProxy in one system is a problem!.
        /// </summary>
        internal static string RegisterDataAccessProxyError {
            get {
                return ResourceManager.GetString("RegisterDataAccessProxyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DataAccessProxySettings {0} is reinitialization by dataAccessProxySettings {1} two dataAccessProxySettings in one system is a problem!.
        /// </summary>
        internal static string RegisterDataAccessProxySettingsError {
            get {
                return ResourceManager.GetString("RegisterDataAccessProxySettingsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to EngineSettings {0} is reinitialization by engineSettings {1} two engineSettings in one system is a problem!.
        /// </summary>
        internal static string RegisterWindowsServiceEngineSettingsError {
            get {
                return ResourceManager.GetString("RegisterWindowsServiceEngineSettingsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is unknown component type.
        /// </summary>
        internal static string UnknownComponentFatal {
            get {
                return ResourceManager.GetString("UnknownComponentFatal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is not initialized.
        /// </summary>
        internal static string WindowsServiceEngineValidateComponentNotInitilizedFatal {
            get {
                return ResourceManager.GetString("WindowsServiceEngineValidateComponentNotInitilizedFatal", resourceCulture);
            }
        }
    }
}