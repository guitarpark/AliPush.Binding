using System;
using Foundation;
using ObjCRuntime;
namespace AliPush.Binding.iOS
{

     //@interface CCPSysMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface CCPSysMessage
    {
        // @property UInt8 messageType;
        [Export("messageType")]
        byte MessageType { get; set; }

        // @property NSData * title;
        [Export("title", ArgumentSemantic.Assign)]
        NSData Title { get; set; }

        // @property NSData * body;
        [Export("body", ArgumentSemantic.Assign)]
        NSData Body { get; set; }
    }

    // @interface CloudPushCallbackResult : NSObject
    [BaseType(typeof(NSObject))]
    interface CloudPushCallbackResult
    {
        // @property (readonly, nonatomic) BOOL success;
        [Export("success")]
        bool Success { get; }

        // @property (readonly, nonatomic) id _Nullable data;
        [NullAllowed, Export("data")]
        NSObject Data { get; }

        // @property (readonly, nonatomic) NSError * _Nullable error;
        [NullAllowed, Export("error")]
        NSError Error { get; }

        // +(instancetype _Nonnull)resultWithData:(id _Nullable)data;
        [Static]
        [Export("resultWithData:")]
        CloudPushCallbackResult ResultWithData([NullAllowed] NSObject data);

        // +(instancetype _Nonnull)resultWithError:(NSError * _Nullable)error;
        [Static]
        [Export("resultWithError:")]
        CloudPushCallbackResult ResultWithError([NullAllowed] NSError error);
    }

    // typedef void (^CallbackHandler)(CloudPushCallbackResult *);
    delegate void CallbackHandler(CloudPushCallbackResult arg0);

    // @interface CloudPushSDK : NSObject
    [BaseType(typeof(NSObject))]
    interface CloudPushSDK
    {
        // +(void)asyncInit:(NSString *)appKey appSecret:(NSString *)appSecret callback:(CallbackHandler)callback;
        [Static]
        [Export("asyncInit:appSecret:callback:")]
        void AsyncInit(string appKey, string appSecret, CallbackHandler callback);

        // +(void)turnOnDebug;
        [Static]
        [Export("turnOnDebug")]
        void TurnOnDebug();

        // +(NSString *)getDeviceId;
        [Static]
        [Export("getDeviceId")]
        string DeviceId { get; }

        // +(NSString *)getVersion;
        [Static]
        [Export("getVersion")]
        string Version { get; }

        // +(BOOL)isChannelOpened;
        [Static]
        [Export("isChannelOpened")]
        bool IsChannelOpened { get; }

        // +(void)sendNotificationAck:(NSDictionary *)userInfo;
        [Static]
        [Export("sendNotificationAck:")]
        void SendNotificationAck(NSDictionary userInfo);

        // +(void)handleLaunching:(NSDictionary *)launchOptions __attribute__((deprecated("Use 'sendNotificationAck:' instead")));
        [Static]
        [Export("handleLaunching:")]
        void HandleLaunching(NSDictionary launchOptions);

        // +(void)handleReceiveRemoteNotification:(NSDictionary *)userInfo __attribute__((deprecated("Use 'sendNotificationAck:' instead")));
        [Static]
        [Export("handleReceiveRemoteNotification:")]
        void HandleReceiveRemoteNotification(NSDictionary userInfo);

        // +(void)bindAccount:(NSString *)account withCallback:(CallbackHandler)callback;
        [Static]
        [Export("bindAccount:withCallback:")]
        void BindAccount(string account, CallbackHandler callback);

        // +(void)unbindAccount:(CallbackHandler)callback;
        [Static]
        [Export("unbindAccount:")]
        void UnbindAccount(CallbackHandler callback);

        // +(void)bindTag:(int)target withTags:(NSArray *)tags withAlias:(NSString *)alias withCallback:(CallbackHandler)callback;
        [Static]
        [Export("bindTag:withTags:withAlias:withCallback:")]
        void BindTag(int target, NSObject[] tags, string alias, CallbackHandler callback);

        // +(void)unbindTag:(int)target withTags:(NSArray *)tags withAlias:(NSString *)alias withCallback:(CallbackHandler)callback;
        [Static]
        [Export("unbindTag:withTags:withAlias:withCallback:")]
        void UnbindTag(int target, NSObject[] tags, string alias, CallbackHandler callback);

        // +(void)listTags:(int)target withCallback:(CallbackHandler)callback;
        [Static]
        [Export("listTags:withCallback:")]
        void ListTags(int target, CallbackHandler callback);

        // +(void)addAlias:(NSString *)alias withCallback:(CallbackHandler)callback;
        [Static]
        [Export("addAlias:withCallback:")]
        void AddAlias(string alias, CallbackHandler callback);

        // +(void)removeAlias:(NSString *)alias withCallback:(CallbackHandler)callback;
        [Static]
        [Export("removeAlias:withCallback:")]
        void RemoveAlias(string alias, CallbackHandler callback);

        // +(void)listAliases:(CallbackHandler)callback;
        [Static]
        [Export("listAliases:")]
        void ListAliases(CallbackHandler callback);

        // +(void)registerDevice:(NSData *)deviceToken withCallback:(CallbackHandler)callback;
        [Static]
        [Export("registerDevice:withCallback:")]
        void RegisterDevice(NSData deviceToken, CallbackHandler callback);

        // +(NSString *)getApnsDeviceToken;
        [Static]
        [Export("getApnsDeviceToken")]
        string ApnsDeviceToken { get; }

        // +(void)syncBadgeNum:(NSUInteger)num withCallback:(CallbackHandler)callback;
        [Static]
        [Export("syncBadgeNum:withCallback:")]
        void SyncBadgeNum(nuint num, CallbackHandler callback);
    }

}
