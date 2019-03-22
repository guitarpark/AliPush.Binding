
using Android.App;
using Android.Content;

namespace com.alibaba.sdk.android.push
{

    [Service(Name = "com.alibaba.sdk.android.push.MsgService", Exported = false), IntentFilter(new string[] { "com.alibaba.sdk.android.push.NOTIFY_ACTION" })]
    public class MsgService
    {
    }

    //[BroadcastReceiver(Name = "com.alibaba.sdk.android.push.AliyunPushIntentService", Exported = true), IntentFilter(new string[] { "org.agoo.android.intent.action.RECEIVE" })]
    //public class AliyunPushIntentService : BroadcastReceiver
    //{
    //    public override void OnReceive(Context context, Intent intent)
    //    {
    //    }
    //}

    //[BroadcastReceiver(Name = "com.alibaba.sdk.android.push.SystemEventReceiver", Process = ":channel"),
    //    IntentFilter(new string[] { "android.intent.action.MEDIA_MOUNTED", "android.intent.action.ACTION_POWER_CONNECTED", "android.intent.action.ACTION_POWER_DISCONNECTED" })]
    //public class SystemEventReceiver : BroadcastReceiver
    //{
    //    public override void OnReceive(Context context, Intent intent)
    //    {
    //    }
    //}

    [BroadcastReceiver(Name = "com.alibaba.sdk.android.push.AgooFirebaseInstanceIDService", Exported = true),
        IntentFilter(new string[] { "com.google.firebase.INSTANCE_ID_EVENT" }, Priority = -500)]
    public class AgooFirebaseInstanceIDService : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
        }
    }

    [BroadcastReceiver(Name = "com.alibaba.sdk.android.push.AgooFirebaseMessagingService", Exported = true),
    IntentFilter(new string[] { "com.google.firebase.MESSAGING_EVENT" }, Priority = -500)]
    public class AgooFirebaseMessagingService : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
        }
    }
}
namespace com.alibaba.sdk.android.push.channel
{

    [Service(Name = "com.alibaba.sdk.android.push.channel.CheckService", Process = ":channel"), IntentFilter(new string[] { "com.alibaba.sdk.android.push.CHECK_SERVICE" })]
    public class CheckService
    {
    }
    [Service(Name = "com.alibaba.sdk.android.push.channel.TaobaoRecvService", Process = ":channel", Exported = true), IntentFilter(new string[] { "org.android.agoo.client.MessageReceiverService" })]
    public class TaobaoRecvService
    {
    }
    [Service(Name = "com.alibaba.sdk.android.push.channel.KeepChannelService", Process = ":channel", Permission = "android.permission.BIND_JOB_SERVICE")]
    public class KeepChannelService
    {
    }
}

namespace com.taobao.accs.@internal
{
    [Service(Name = "com.taobao.accs.internal.AccsJobServicee", Process = ":channel", Permission = "android.permission.BIND_JOB_SERVICE")]
    public class AccsJobServicee
    {
    }
}

namespace com.taobao.accs.intent.action
{
    [Service(Name = "com.taobao.accs.data.MsgDistributeService", Exported = true), IntentFilter(new string[] { "com.taobao.accs.intent.action.RECEIVE" })]//不确定 namespace不同
    public class MsgDistributeService
    {
    }

}
namespace com.taobao.accs
{
    [Service(Name = "com.taobao.accs.ChannelService", Exported = true), IntentFilter(new string[] { "com.taobao.accs.intent.action.SERVICE" })]
    public class ChannelService
    {
    }

    [Service(Name = "com.taobao.accs.ChannelService$KernelService", Exported = false, Process = ":channel")] //不确定，类名不同
    public class KernelService
    {
    }
    //[BroadcastReceiver(Name = "com.taobao.accs.EventReceiver", Process = ":channel"),
    //IntentFilter(new string[] { "android.intent.action.BOOT_COMPLETED", "android.net.conn.CONNECTIVITY_CHANGE", "android.intent.action.USER_PRESENT" })]
    //[IntentFilter(new string[] { "android.intent.action.PACKAGE_REMOVED" }, DataScheme = "package")]
    //public class EventReceiver : BroadcastReceiver
    //{
    //    public override void OnReceive(Context context, Intent intent)
    //    {
    //    }
    //}

//    [BroadcastReceiver(Name = "com.taobao.accs.ServiceReceiver", Process = ":channel"),
//IntentFilter(new string[] { "com.taobao.accs.intent.action.COMMAND", "com.taobao.accs.intent.action.START_FROM_AGOO" })]
//    public class ServiceReceiver : BroadcastReceiver
//    {
//        public override void OnReceive(Context context, Intent intent)
//        {
//        }
//    }

//    [BroadcastReceiver(Name = "org.android.agoo.accs.AgooService", Exported = true),
//IntentFilter(new string[] { "com.taobao.accs.intent.action.RECEIVE" })]
//    public class AgooService : BroadcastReceiver
//    {
//        public override void OnReceive(Context context, Intent intent)
//        {
//        }
//    }
}

//namespace com.taobao.agoo
//{

//    [BroadcastReceiver(Name = "com.taobao.agoo.AgooCommondReceiver", Exported = true, Process = ":channel"), IntentFilter(new string[] { "${applicationId}.intent.action.COMMAND" })]
//    [IntentFilter(new string[] { "android.intent.action.PACKAGE_REMOVED" }, DataScheme = "package")]
//    public class AgooCommondReceiver : BroadcastReceiver
//    {
//        public override void OnReceive(Context context, Intent intent)
//        {
//        }
//    }
//}

//namespace com.alibaba.sdk.android.push.keeplive
//{
//    [Activity(Exported = false, Name = "com.alibaba.sdk.android.push.keeplive.PushExtActivity", ConfigurationChanges = Android.Content.PM.ConfigChanges.KeyboardHidden | Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Navigation | Android.Content.PM.ConfigChanges.Keyboard,
//        ExcludeFromRecents = true, FinishOnTaskLaunch = false, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance, Theme = "@android:style/Theme.Translucent.NoTitleBar.Fullscreen", Process = ":channel"
//        )

//        ]
//    public class PushExtActivity : Activity
//    {

//    }
//}



namespace com.google.firebase.iid
{
    [BroadcastReceiver(Name = "com.google.firebase.iid.FirebaseInstanceIdReceiver", Exported = true, Permission = "com.google.android.c2dm.permission.SEND"), IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE", "com.google.android.c2dm.intent.REGISTRATION", "com.taobao.taobao" })]
    public class FirebaseInstanceIdReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
        }
    }

    [BroadcastReceiver(Name = "com.google.firebase.iid.FirebaseInstanceIdInternalReceiver", Exported = false)]
    public class FirebaseInstanceIdInternalReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
        }
    }
}
