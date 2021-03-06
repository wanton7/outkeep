﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Outkeep.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Outkeep.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Cache Grain for key {0} cannot clear state because a prior read has failed.
        /// </summary>
        internal static string Exception_CacheGrainForKey_X_CannotClearBecausePendingReadFailed {
            get {
                return ResourceManager.GetString("Exception_CacheGrainForKey_X_CannotClearBecausePendingReadFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Grain for key {0} cannot execute a new storage operation because the prior operation has failed.
        /// </summary>
        internal static string Exception_CacheGrainForKey_X_CannotExecuteStorageOperationBecauseThePriorOperationFailed {
            get {
                return ResourceManager.GetString("Exception_CacheGrainForKey_X_CannotExecuteStorageOperationBecauseThePriorOperatio" +
                        "nFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Grain for key {0} cannot write state because a prior read has failed.
        /// </summary>
        internal static string Exception_CacheGrainForKey_X_CannotWriteBecausePendingReadFailed {
            get {
                return ResourceManager.GetString("Exception_CacheGrainForKey_X_CannotWriteBecausePendingReadFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot execute batched storage operation because the prior operation failed.
        /// </summary>
        internal static string Exception_CannotExecuteStorageOperationBecauseThePriorOperationFailed {
            get {
                return ResourceManager.GetString("Exception_CannotExecuteStorageOperationBecauseThePriorOperationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No default Resource Governor found for grain type {0}.
        /// </summary>
        internal static string Exception_NoDefaultResourceGovernorFoundForGrainType_X {
            get {
                return ResourceManager.GetString("Exception_NoDefaultResourceGovernorFoundForGrainType_X", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Resource Governor named {0} found for grain type {1}.
        /// </summary>
        internal static string Exception_NoResourceGovernorNamed_X_FoundForGrainType_X {
            get {
                return ResourceManager.GetString("Exception_NoResourceGovernorNamed_X_FoundForGrainType_X", resourceCulture);
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
        ///   Looks up a localized string similar to Attempting to deactivate {Count} grains out of {Total} in response to memory pressure.
        /// </summary>
        internal static string Log_AttemptingToDeactivate_X_GrainsOutOf_X_InResponseToMemoryPressure {
            get {
                return ResourceManager.GetString("Log_AttemptingToDeactivate_X_GrainsOutOf_X_InResponseToMemoryPressure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Cache Director Grain Service has encountered an error.
        /// </summary>
        internal static string Log_CachedDirectorGrainServiceError {
            get {
                return ResourceManager.GetString("Log_CachedDirectorGrainServiceError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Cache Director Grain Service has started.
        /// </summary>
        internal static string Log_CacheDirectorGrainServiceStarted {
            get {
                return ResourceManager.GetString("Log_CacheDirectorGrainServiceStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Cache Director Grain Service has stopped.
        /// </summary>
        internal static string Log_CacheDirectorGrainServiceStopped {
            get {
                return ResourceManager.GetString("Log_CacheDirectorGrainServiceStopped", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Grain for key {Key} failed and will be deactivated now.
        /// </summary>
        internal static string Log_CacheGrainForKey_X_FailedAndWillBeDeactivatedNow {
            get {
                return ResourceManager.GetString("Log_CacheGrainForKey_X_FailedAndWillBeDeactivatedNow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Echo {Message}.
        /// </summary>
        internal static string Log_Echo_X {
            get {
                return ResourceManager.GetString("Log_Echo_X", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to deactivate one or more target grains.
        /// </summary>
        internal static string Log_FailedToDeactivateOneOrMoreTargetGrains {
            get {
                return ResourceManager.GetString("Log_FailedToDeactivateOneOrMoreTargetGrains", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to deactivate target grain {GrainReference}.
        /// </summary>
        internal static string Log_FailedToDeactivateTargetGrain_X {
            get {
                return ResourceManager.GetString("Log_FailedToDeactivateTargetGrain_X", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to deactivate target grain {GrainReference} after {MaxAttempts} attempts. Will not retry..
        /// </summary>
        internal static string Log_FailedToDeactivateTargetGrain_X_After_X_AttemptsWillNotRetry {
            get {
                return ResourceManager.GetString("Log_FailedToDeactivateTargetGrain_X_After_X_AttemptsWillNotRetry", resourceCulture);
            }
        }
    }
}
