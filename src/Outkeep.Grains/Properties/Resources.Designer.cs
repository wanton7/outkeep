﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Outkeep.Grains.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Outkeep.Grains.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Cache Grain for key {0} cannot clear state because a prior read has failed..
        /// </summary>
        internal static string Exception_CacheGrainForKey_X_CannotClearBecausePendingReadFailed {
            get {
                return ResourceManager.GetString("Exception_CacheGrainForKey_X_CannotClearBecausePendingReadFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Grain for key {0} cannot execute a new storage operation because the prior operation has failed..
        /// </summary>
        internal static string Exception_CacheGrainForKey_X_CannotExecuteStorageOperationBecauseThePriorOperationFailed {
            get {
                return ResourceManager.GetString("Exception_CacheGrainForKey_X_CannotExecuteStorageOperationBecauseThePriorOperatio" +
                        "nFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Grain for key {0} cannot write state because a prior read has failed..
        /// </summary>
        internal static string Exception_CacheGrainForKey_X_CannotWriteBecausePendingReadFailed {
            get {
                return ResourceManager.GetString("Exception_CacheGrainForKey_X_CannotWriteBecausePendingReadFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} must be a positive {1}.
        /// </summary>
        internal static string Exception_XMustBeAPositiveX {
            get {
                return ResourceManager.GetString("Exception_XMustBeAPositiveX", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Grain for key {Key} failed and will be deactivated now..
        /// </summary>
        internal static string Log_CacheGrainForKey_X_FailedAndWillBeDeactivatedNow {
            get {
                return ResourceManager.GetString("Log_CacheGrainForKey_X_FailedAndWillBeDeactivatedNow", resourceCulture);
            }
        }
    }
}
