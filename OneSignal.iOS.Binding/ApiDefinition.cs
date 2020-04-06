using System;
using Foundation;
using OSNotificationDisplayType = Com.OneSignal.iOS.OSInFocusDisplayOption;
using OSSession = Com.OneSignal.iOS.OSSession;
using UserNotifications;
using ObjCRuntime;

namespace Com.OneSignal.iOS
{

   // @interface OSOutcomeEvent
   [BaseType(typeof(NSObject))]
   interface OSOutcomeEvent
   {
      // @property (nonatomic) Session session;
      [Export("session")]
      OSSession Session { get; }

      // @property (strong, nonatomic, nullable) NSArray *notificationIds;
      [Export("notificationIds")]
      string[] NotificationIds { get; }

      // @property (strong, nonatomic, nonnull) NSString *name;
      [Export("name")]
      string Name { get; }

      // @property (strong, nonatomic, nonnull) NSNumber *timestamp;
      [Export("timestamp")]
      long Timestamp { get; }

      // @property (strong, nonatomic, nonnull) NSDecimalNumber *weight;
      [Export("weight")]
      float Weight { get; }

      //- (NSDictionary * _Nonnull)jsonRepresentation;
      [Export("jsonRepresentation")]
      NSDictionary JsonRepresentation();
   }

   // @interface OSInAppMessageAction
   [BaseType (typeof(NSObject))]
   interface OSInAppMessageAction
   {
	   // @property (nonatomic, strong) NSString * _Nullable clickName;
	   [Export ("clickName")]
	   string ClickName { get; set; }

	   // @property (nonatomic, strong) NSURL * _Nullable clickUrl;
	   [Export ("clickUrl")]
	   NSUrl ClickUrl { get; set; }

	   // @property (nonatomic) BOOL firstClick;
	   [Export ("firstClick")]
	   bool FirstClick { get; set; }

	   // @property (nonatomic) BOOL closesMessage;
	   [Export ("closesMessage")]
	   bool ClosesMessage { get; set; }
   }

   // @protocol OSInAppMessageDelegate
   [Protocol, Model (AutoGeneratedName = true)]
   interface OSInAppMessageDelegate
   {
	   // @optional -(void)handleMessageAction:(OSInAppMessageAction * _Nonnull)action;
	   [Export ("handleMessageAction:")]
	   void HandleMessageAction (OSInAppMessageAction action);
   }

   // @interface OSNotificationAction : NSObject
   [BaseType (typeof(NSObject))]
	interface OSNotificationAction
	{
		// @property (readonly) OSNotificationActionType type;
		[Export ("type")]
		OSNotificationActionType Type { get; }

		// @property (readonly) NSString * actionID;
		[Export ("actionID")]
		string ActionID { get; }
	}

	// @interface OSNotificationPayload : NSObject
	[BaseType (typeof(NSObject))]
	interface OSNotificationPayload
	{
		// @property (readonly) NSString * notificationID;
		[Export ("notificationID")]
		string NotificationID { get; }

		// @property (readonly) BOOL contentAvailable;
		[Export ("contentAvailable")]
		bool ContentAvailable { get; }

		// @property (readonly) NSUInteger badge;
		[Export ("badge")]
		nuint Badge { get; }

		// @property (readonly) NSString * sound;
		[Export ("sound")]
		string Sound { get; }

		// @property (readonly) NSString * title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly) NSString * subtitle;
		[Export ("subtitle")]
		string Subtitle { get; }

		// @property (readonly) NSString * body;
		[Export ("body")]
		string Body { get; }

		// @property (readonly) NSString * launchURL;
		[Export ("launchURL")]
		string LaunchURL { get; }

		// @property (readonly) NSDictionary * additionalData;
		[Export ("additionalData")]
		NSDictionary AdditionalData { get; }

		// @property (readonly) NSDictionary * attachments;
		[Export ("attachments")]
		NSDictionary Attachments { get; }

		// @property (readonly) NSArray * actionButtons;
		[Export ("actionButtons")]
		NSArray ActionButtons { get; }

		// @property (readonly) NSDictionary * rawPayload;
		[Export ("rawPayload")]
		NSDictionary RawPayload { get; }
	}

	// @interface OSNotification : NSObject
	[BaseType (typeof(NSObject))]
	interface OSNotification
	{
		// @property (readonly) OSNotificationPayload * payload;
		[Export ("payload")]
		OSNotificationPayload Payload { get; }

		// @property (readonly) OSNotificationDisplayType displayType;
		[Export ("displayType")]
		OSNotificationDisplayType DisplayType { get; }

		// @property (readonly, getter = wasShown) BOOL shown;
		[Export ("shown")]
		bool Shown { [Bind ("wasShown")] get; }

		// @property (readonly, getter = wasAppInFocus) BOOL isAppInFocus;
		[Export ("isAppInFocus")]
		bool IsAppInFocus { [Bind ("wasAppInFocus")] get; }

		// @property (readonly, getter = isSilentNotification) BOOL silentNotification;
		[Export ("silentNotification")]
		bool SilentNotification { [Bind ("isSilentNotification")] get; }

		// @property (readonly, getter = hasMutableContent) BOOL mutableContent;
		[Export ("mutableContent")]
		bool MutableContent { [Bind ("hasMutableContent")] get; }

		// -(NSString *)stringify;
		[Export ("stringify")]
		string Stringify { get; }
	}

	// @interface OSNotificationOpenedResult : NSObject
	[BaseType (typeof(NSObject))]
	interface OSNotificationOpenedResult
	{
		// @property (readonly) OSNotification * notification;
		[Export ("notification")]
		OSNotification Notification { get; }

		// @property (readonly) OSNotificationAction * action;
		[Export ("action")]
		OSNotificationAction Action { get; }

		// -(NSString *)stringify;
		[Export ("stringify")]
		string Stringify { get; }
	}

	// typedef void (^OSResultSuccessBlock)(NSDictionary *);
	delegate void OSResultSuccessBlock(NSDictionary arg0);

	// typedef void (^OSFailureBlock)(NSError *);
	delegate void OSFailureBlock(NSError arg0);

   // typedef void (^OSResultEmailSuccessBlock)();
   delegate void OSEmailSuccessBlock();

   // typedef void (^OSEmailFailureBlock)();
   delegate void OSEmailFailureBlock(NSError arg0);

   // typedef void (^OSUpdateExternalUserIdBlock)();
   delegate void OSUpdateExternalUserIdBlock(NSDictionary arg0);

	// typedef void (^OSIdsAvailableBlock)(NSString *, NSString *);
	delegate void OSIdsAvailableBlock(string arg0, string arg1);

	// typedef void (^OSHandleNotificationReceivedBlock)(OSNotification *);
	delegate void OSHandleNotificationReceivedBlock(OSNotification arg0);

	// typedef void (^OSHandleNotificationActionBlock)(OSNotificationOpenedResult *);
	delegate void OSHandleNotificationActionBlock(OSNotificationOpenedResult arg0);

   // typedef void (^OSHandleInAppMessageActionClickBlock)(OSInAppMessageAction *);
   delegate void OSHandleInAppMessageActionClickBlock(OSInAppMessageAction arg0);

   // typedef void (^OSSendOutcomeSuccess)();
   delegate void OSSendOutcomeSuccess(OSOutcomeEvent arg0);

   partial interface Constants
	{
		// extern NSString *const kOSSettingsKeyAutoPrompt;
		[Field ("kOSSettingsKeyAutoPrompt", "__Internal")]
		NSString kOSSettingsKeyAutoPrompt { get; }

		// extern NSString *const kOSSettingsKeyInAppAlerts;
		[Field ("kOSSettingsKeyInAppAlerts", "__Internal")]
		NSString kOSSettingsKeyInAppAlerts { get; }

		// extern NSString *const kOSSettingsKeyInAppLaunchURL;
		[Field ("kOSSettingsKeyInAppLaunchURL", "__Internal")]
		NSString kOSSettingsKeyInAppLaunchURL { get; }

		// extern NSString *const kOSSettingsKeyInFocusDisplayOption;
		[Field ("kOSSettingsKeyInFocusDisplayOption", "__Internal")]
		NSString kOSSettingsKeyInFocusDisplayOption { get; }
	}

	// @interface OneSignal : NSObject
	[BaseType (typeof(NSObject))]
	interface OneSignal
	{
		//+ (id)initWithLaunchOptions:(NSDictionary *)launchOptions appId:(NSString *)appId;
		[Static]
		[Export ("initWithLaunchOptions:appId:")]
		NSObject InitWithLaunchOptions (NSDictionary launchOptions, string appId);

		//+ (id)initWithLaunchOptions:(NSDictionary *)launchOptions appId:(NSString *)appId handleNotificationAction:(OSHandleNotificationActionBlock)actionCallback;
		[Static]
		[Export ("initWithLaunchOptions:appId:handleNotificationAction:")]
		NSObject InitWithLaunchOptions (NSDictionary launchOptions, string appId, OSHandleNotificationActionBlock actionCallback);

		//+ (id)initWithLaunchOptions:(NSDictionary *)launchOptions appId:(NSString *)appId handleNotificationAction:(OSHandleNotificationActionBlock)actionCallback settings:(NSDictionary *)settings;
		[Static]
		[Export ("initWithLaunchOptions:appId:handleNotificationAction:settings:")]
		NSObject InitWithLaunchOptions (NSDictionary launchOptions, string appId, OSHandleNotificationActionBlock actionCallback, NSDictionary settings);

		//+ (id)initWithLaunchOptions:(NSDictionary *)launchOptions appId:(NSString *)appId handleNotificationReceived:(OSHandleNotificationReceivedBlock)receivedCallback handleNotificationAction:(OSHandleNotificationActionBlock)actionCallback settings:(NSDictionary *)settings;
		[Static]
		[Export ("initWithLaunchOptions:appId:handleNotificationReceived:handleNotificationAction:settings:")]
		NSObject InitWithLaunchOptions (NSDictionary launchOptions, string appId, OSHandleNotificationReceivedBlock receivedCallback, OSHandleNotificationActionBlock actionCallback, NSDictionary settings);

		//+ (NSString *)app_id;
		[Static]
		[Export ("app_id")]
		string App_id { get; }

		//+ (void)registerForPushNotifications;
		[Static]
		[Export ("registerForPushNotifications")]
		void RegisterForPushNotifications ();

		//+ (void)setLogLevel:(ONE_S_LOG_LEVEL)logLevel visualLevel:(ONE_S_LOG_LEVEL)visualLogLevel;
		[Static]
		[Export ("setLogLevel:visualLevel:")]
		void SetLogLevel (OneSLogLevel logLevel, OneSLogLevel visualLogLevel);

		//+ (void)onesignal_Log:(ONE_S_LOG_LEVEL)logLevel message:(NSString *)message;
		[Static]
		[Export ("onesignal_Log:message:")]
		void Onesignal_Log (OneSLogLevel logLevel, string message);

		//+ (void)sendTag:(NSString *)key value:(NSString *)value onSuccess:(OSResultSuccessBlock)successBlock onFailure:(OSFailureBlock)failureBlock;
		[Static]
		[Export ("sendTag:value:onSuccess:onFailure:")]
		void SendTag (string key, string value, OSResultSuccessBlock successBlock, OSFailureBlock failureBlock);

		//+ (void)sendTag:(NSString *)key value:(NSString *)value;
		[Static]
		[Export ("sendTag:value:")]
		void SendTag (string key, string value);

		//+ (void)sendTags:(NSDictionary *)keyValuePair onSuccess:(OSResultSuccessBlock)successBlock onFailure:(OSFailureBlock)failureBlock;
		[Static]
		[Export ("sendTags:onSuccess:onFailure:")]
		void SendTags (NSDictionary keyValuePair, OSResultSuccessBlock successBlock, OSFailureBlock failureBlock);

		//+ (void)sendTags:(NSDictionary *)keyValuePair;
		[Static]
		[Export ("sendTags:")]
		void SendTags (NSDictionary keyValuePair);

		//+ (void)sendTagsWithJsonString:(NSString *)jsonString;
		[Static]
		[Export ("sendTagsWithJsonString:")]
		void SendTagsWithJsonString (string jsonString);

		//+ (void)getTags:(OSResultSuccessBlock)successBlock onFailure:(OSFailureBlock)failureBlock;
		[Static]
		[Export ("getTags:onFailure:")]
		void GetTags (OSResultSuccessBlock successBlock, OSFailureBlock failureBlock);

		//+ (void)getTags:(OSResultSuccessBlock)successBlock;
		[Static]
		[Export ("getTags:")]
		void GetTags (OSResultSuccessBlock successBlock);

		//+ (void)deleteTag:(NSString *)key onSuccess:(OSResultSuccessBlock)successBlock onFailure:(OSFailureBlock)failureBlock;
		[Static]
		[Export ("deleteTag:onSuccess:onFailure:")]
		void DeleteTag (string key, OSResultSuccessBlock successBlock, OSFailureBlock failureBlock);

		//+ (void)deleteTag:(NSString *)key;
		[Static]
		[Export ("deleteTag:")]
		void DeleteTag (string key);

		//+ (void)deleteTags:(NSArray *)keys onSuccess:(OSResultSuccessBlock)successBlock onFailure:(OSFailureBlock)failureBlock;
		[Static]
		[Export ("deleteTags:onSuccess:onFailure:")]
		void DeleteTags (NSObject[] keys, OSResultSuccessBlock successBlock, OSFailureBlock failureBlock);

		//+ (void)deleteTags:(NSArray *)keys;
		[Static]
		[Export ("deleteTags:")]
		void DeleteTags (NSObject[] keys);

		//+ (void)deleteTagsWithJsonString:(NSString *)jsonString;
		[Static]
		[Export ("deleteTagsWithJsonString:")]
		void DeleteTagsWithJsonString (string jsonString);

		//+ (void)IdsAvailable:(OSIdsAvailableBlock)idsAvailableBlock;
		[Static]
		[Export ("IdsAvailable:")]
		void IdsAvailable (OSIdsAvailableBlock idsAvailableBlock);

		//+ (void)setSubscription:(BOOL)enable;
		[Static]
		[Export ("setSubscription:")]
		void SetSubscription (bool enable);

		//+ (void)postNotification:(NSDictionary *)jsonData;
		[Static]
		[Export ("postNotification:")]
		void PostNotification (NSDictionary jsonData);

		//+ (void)postNotification:(NSDictionary *)jsonData onSuccess:(OSResultSuccessBlock)successBlock onFailure:(OSFailureBlock)failureBlock;
		[Static]
		[Export ("postNotification:onSuccess:onFailure:")]
		void PostNotification (NSDictionary jsonData, OSResultSuccessBlock successBlock, OSFailureBlock failureBlock);

		//+ (void)postNotificationWithJsonString:(NSString *)jsonData onSuccess:(OSResultSuccessBlock)successBlock onFailure:(OSFailureBlock)failureBlock;
		[Static]
		[Export ("postNotificationWithJsonString:onSuccess:onFailure:")]
		void PostNotificationWithJsonString (string jsonData, OSResultSuccessBlock successBlock, OSFailureBlock failureBlock);

		//+ (NSString *)parseNSErrorAsJsonString:(NSError *)error;
		[Static]
		[Export ("parseNSErrorAsJsonString:")]
		string ParseNSErrorAsJsonString (NSError error);

		//+ (void)promptLocation;
		[Static]
		[Export ("promptLocation")]
		void PromptLocation ();

		//+ (void)setLocationShared:(BOOL)enable;
		[Static]
		[Export ("setLocationShared:")]
		void SetLocationShared (bool enable);

		//+ (void)syncHashedEmail:(NSString *)email;
		[Static]
		[Export ("syncHashedEmail:")]
		void SyncHashedEmail (string email);

      //+ (void)setEmail:(NSString * _Nonnull)email withEmailAuthHashToken:(NSString * _Nullable)hashToken withSuccess:(OSEmailSuccessBlock _Nullable)successBlock withFailure:(OSEmailFailureBlock _Nullable)failureBlock;
      [Static]
      [Export("setEmail:withEmailAuthHashToken:withSuccess:withFailure:")]
      void SetEmail(string email, string emailAuthToken, OSEmailSuccessBlock successBlock, OSEmailFailureBlock failureBlock);
      
      //+ (void)setEmail:(NSString * _Nonnull)email withSuccess:(OSEmailSuccessBlock _Nullable)successBlock withFailure:(OSEmailFailureBlock _Nullable)failureBlock;
      [Static]
      [Export ("setEmail:withSuccess:withFailure:")]
      void SetEmail(string email, OSEmailSuccessBlock successBlock, OSEmailFailureBlock failureBlock);
      
      //+ (void)logoutEmailWithSuccess:(OSEmailSuccessBlock _Nullable)successBlock withFailure:(OSEmailFailureBlock _Nullable)failureBlock;
      [Static]
      [Export("logoutEmailWithSuccess:withFailure:")]
      void LogoutEmail(OSEmailSuccessBlock successBlock, OSEmailFailureBlock failureBlock);
      
      //+ (void)setMSDKType:(NSString *)type;
      [Static]
      [Export("setMSDKType:")]
      void SetMSDKType(string type);

      //+ (void)setInAppMessageClickHandler:(OSHandleInAppMessageActionClickBlock)delegate;
	   [Static]
	   [Export ("setInAppMessageClickHandler:")]
	   void SetInAppMessageClickHandler (OSHandleInAppMessageActionClickBlock @delegate);
      
      //+ (UNMutableNotificationContent*)didReceiveNotificationExtensionRequest:(UNNotificationRequest*)request withMutableNotificationContent:(UNMutableNotificationContent*)replacementContent;
      [Static]
      [Export("didReceiveNotificationExtensionRequest:withMutableNotificationContent:")]
      void DidReceiveNotificationExtensionRequest(UNNotificationRequest request, UNMutableNotificationContent replacementContent);
      
      //+ (UNMutableNotificationContent*)serviceExtensionTimeWillExpireRequest:(UNNotificationRequest*)request withMutableNotificationContent:(UNMutableNotificationContent*)replacementContent;
      [Static]
      [Export("serviceExtensionTimeWillExpireRequest:withMutableNotificationContent:")]
      void ServiceExtensionTimeWillExpireRequest(UNNotificationRequest request, UNMutableNotificationContent replacementContent);

      //+ (void)consentGranted:(BOOL)granted;
      [Static]
      [Export("consentGranted:")]
      void ConsentGranted(bool granted);

      //+ (BOOL)requiresUserPrivacyConsent;
      [Static]
      [Export("requiresUserPrivacyConsent")]
      bool RequiresUserPrivacyConsent();

      //+ (void)setRequiresUserPrivacyConsent:(BOOL)required;
      [Static]
      [Export("setRequiresUserPrivacyConsent:")]
      void SetRequiresUserPrivacyConsent(bool required);

      //+ (void)setExternalUserId(NSString *)externalId;
      [Static]
      [Export("setExternalUserId:")]
      void SetExternalUserId(string externalId);

      //+ (void)setExternalUserId:(NSString * _Nonnull)externalId withCompletion:(OSUpdateExternalUserIdBlock _Nullable)completionBlock;
      [Static]
      [Export("setExternalUserId:withCompletion:")]
      void SetExternalUserId(string externalId, OSUpdateExternalUserIdBlock completionCallback);

      //+ (void)removeExternalUserId;
      [Static]
      [Export("removeExternalUserId")]
      void RemoveExternalUserId();

      //+ (void)removeExternalUserId:(OSUpdateExternalUserIdBlock _Nullable)completionBlock;
      [Static]
      [Export("removeExternalUserId:")]
      void RemoveExternalUserId(OSUpdateExternalUserIdBlock completionBlock);

      //+ (void)addTrigger:(NSString *)key withValue:(id)value;
      [Static]
      [Export("addTrigger:withValue:")]
      void AddTrigger(string key, NSObject value);

      //+ addTriggers:(NSDictionary<NSString *, id> *)triggers;
      [Static]
      [Export("addTriggers:")]
      void AddTriggers(NSDictionary triggers);

      //+ (void)removeTriggerForKey:(NSString *)key;
      [Static]
      [Export("removeTriggerForKey:")]
      void RemoveTriggerForKey(string key);

      //+ (void) removeTriggersForKeys:(NSArray<NSString*>*) keys;
      [Static]
      [Export("removeTriggersForKeys:")]
      void RemoveTriggersForKeys(NSArray keys);

      //+ (id)getTriggerValueForKey:(NSString *)key
      [Static]
      [Export("getTriggerValueForKey:")]
      NSObject GetTriggerValueForKey(string key);

      //+ (void)pauseInAppMessages:(BOOL)pause
      [Static]
      [Export("pauseInAppMessages:")]
      void PauseInAppMessages(bool pause);

      //+ (void)sendOutcome:(NSString* _Nonnull)name;
      [Static]
      [Export("sendOutcome:")]
      void SendOutcome(string name);

      //+ (void)sendOutcome:(NSString* _Nonnull)name onSuccess:(OSSendOutcomeSuccess _Nullable)success;
      [Static]
      [Export("sendOutcome:onSuccess:")]
      void SendOutcome(string name, OSSendOutcomeSuccess callback);

      //+ (void)sendUniqueOutcome:(NSString* _Nonnull)name;
      [Static]
      [Export("sendUniqueOutcome:")]
      void SendUniqueOutcome(string name);

      //+ (void)sendUniqueOutcome:(NSString* _Nonnull)name onSuccess:(OSSendOutcomeSuccess _Nullable)success;
      [Static]
      [Export("sendUniqueOutcome:onSuccess:")]
      void SendUniqueOutcome(string name, OSSendOutcomeSuccess callback);

      //+ (void)sendOutcomeWithValue:(NSString* _Nonnull)name value:(NSNumber* _Nonnull)value;
      [Static]
      [Export("sendOutcomeWithValue:value:")]
      void SendOutcomeWithValue(string name, NSNumber value);

      //+ (void)sendOutcomeWithValue:(NSString* _Nonnull)name value:(NSNumber* _Nonnull)value onSuccess:(OSSendOutcomeSuccess _Nullable)success;
      [Static]
      [Export("sendOutcomeWithValue:value:onSuccess:")]
      void SendOutcomeWithValue(string name, NSNumber value, OSSendOutcomeSuccess callback);
   }

   partial interface Constants
	{
		// extern NSString *const ONESIGNAL_VERSION;
		[Field ("ONESIGNAL_VERSION", "__Internal")]
		NSString ONESIGNAL_VERSION { get; }
	}
}
