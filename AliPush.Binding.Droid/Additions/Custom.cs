using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AliPush.Binding.Droid
{
    public class AliPushConfig
    {
        /// <summary>
        /// 包名
        /// </summary>
        public const string PackageName="";


        [BroadcastReceiver(Name = PackageName+".AliPushReceiver"), IntentFilter(new string[] { "com.alibaba.push2.action.NOTIFICATION_OPENED", "com.alibaba.push2.action.NOTIFICATION_REMOVED", "com.taobao.accs.intent.action.COMMAND", "com.taobao.taobao.intent.action.COMMAND", "com.alibaba.sdk.android.push.RECEIVE", "android.net.conn.CONNECTIVITY_CHANGE", "android.intent.action.USER_PRESENT", "android.intent.action.BOOT_COMPLETED" })]
        [IntentFilter(new string[] { "android.intent.action.PACKAGE_REMOVED" }, DataScheme = "package")]
        public class AliPushReceiver : BroadcastReceiver
        {
            public override void OnReceive(Android.Content.Context context, Intent intent)
            {
            }
        }
        [Activity(Exported = true, Name = "com.guitarpark.app.Activitys.PopupPushActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
        public class PushExtActivity : Activity
        {

        }
    }

}