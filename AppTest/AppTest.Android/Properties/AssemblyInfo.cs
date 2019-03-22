using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Android.App;
using Android.Content;
using Android.Runtime;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("AppTest.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AppTest.Android")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]


#region 阿里推送相关权限
[assembly: UsesPermission(Android.Manifest.Permission.WriteSettings)]//Android 6.0版本可去除，用于选举信息（通道复用）的同步
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]//进行网络访问和网络状态监控相关的权限声明-
[assembly: UsesPermission(Android.Manifest.Permission.AccessWifiState)]//进行网络访问和网络状态监控相关的权限声明-
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]//允许对sd卡进行读写操作
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]//允许对sd卡进行读写操作
[assembly: UsesPermission(Android.Manifest.Permission.WakeLock)]//网络库使用，当网络操作时需要确保事务完成不被杀掉
[assembly: UsesPermission(Android.Manifest.Permission.ReadPhoneState)]//用于读取手机硬件信息等，用于机型过滤
[assembly: UsesPermission(Android.Manifest.Permission.BroadcastPackageRemoved)]//选举使用，当应用有删除或者更新时需要重新选举，复用推送通道
[assembly: UsesPermission(Android.Manifest.Permission.RestartPackages)]//选举使用，当应用有删除或者更新时需要重新选举，复用推送通道
[assembly: UsesPermission(Android.Manifest.Permission.GetTasks)]//补偿通道小米PUSH使用，不用可去除
[assembly: UsesPermission(Android.Manifest.Permission.GetAccounts)]//补偿通道GCM使用，不使用可去除
[assembly: UsesPermission(Android.Manifest.Permission.ReceiveBootCompleted)]//允许监听启动完成事件
[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]//震动
[assembly: UsesPermission(Android.Manifest.Permission.ReorderTasks)]//允许task重排序
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]//网络
[assembly: UsesPermission(Android.Manifest.Permission.ModifyAudioSettings)]//声音设置

#region 小米相关
#endregion
[assembly: Permission(Name = AliPush.Binding.Droid.AliPushConfig.PackageName + ".permission.MIPUSH_RECEIVE", ProtectionLevel = Android.Content.PM.Protection.Signature)]
[assembly: UsesPermission(AliPushConfig.PackageName + ".permission.MIPUSH_RECEIVE")]
#endregion

[assembly: MetaData(name: "com.alibaba.app.appkey", Value = "--------需要填写--------")]
[assembly: MetaData(name: "com.alibaba.app.appsecret", Value = "--------需要填写--------")]

public static class AliPushConfig
{
    /// <summary>
    /// 包名
    /// </summary>
    public const string PackageName = "com.guitarpark.app";

}

namespace com.guitarpark.app//写一个类，继承就好了

{
    [BroadcastReceiver(Name = AliPushConfig.PackageName+".AliPushReceiver"), IntentFilter(new string[] { "com.alibaba.push2.action.NOTIFICATION_OPENED", "com.alibaba.push2.action.NOTIFICATION_REMOVED", "com.taobao.accs.intent.action.COMMAND", "com.taobao.taobao.intent.action.COMMAND", "com.alibaba.sdk.android.push.RECEIVE", "android.net.conn.CONNECTIVITY_CHANGE", "android.intent.action.USER_PRESENT", "android.intent.action.BOOT_COMPLETED" })]
    [IntentFilter(new string[] { "android.intent.action.PACKAGE_REMOVED" }, DataScheme = "package")]
    public class AliPushReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
        }
    }
    [Activity(Exported = true, Name = "com.guitarpark.app.Activitys.PopupPushActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class PushExtActivity : Activity
    {

    }
}

namespace AliPushCallBack
{
    [Application(Name = AliPushConfig.PackageName + ".MainApplication")]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            InitCloudChannel(this);
            //app init ...


            //初始化云推送通道
            //InitCloudChannel(this);
            //test
            //Intent intent = new Intent();
            //intent.SetAction("com.alibaba.sdk.android.push.RECEIVE");
            //intent.SetPackage("com.yishi.onetoo.app");//pack为应用包名
            //intent.PutExtra("type", "common-push");
            //intent.AddFlags((ActivityFlags)32);
            //this.SendBroadcast(intent);
        }

        #region  初始化云推送通道

        private void InitCloudChannel(Android.Content.Context applicationContext)
        {
            Com.Alibaba.Sdk.Android.Push.Noonesdk.PushServiceFactory.Init(applicationContext);
            Com.Alibaba.Sdk.Android.Push.ICloudPushService pushService = Com.Alibaba.Sdk.Android.Push.Noonesdk.PushServiceFactory.CloudPushService;
            pushService.Register(applicationContext, new PushCommonCallback());
            //注册方法会自动判断是否支持小米系统推送，如不支持会跳过注册。
            //MiPushRegister.Register(applicationContext, AliPushConfig.XiaoMiAppId, AliPushConfig.XiaoMiAppKey);
            // 注册方法会自动判断是否支持华为系统推送，如不支持会跳过注册。
            //HuaWeiRegister.Register(applicationContext);
            // 记录deviceid
            var fff = pushService.DeviceId;
        }

        #endregion

    }

    public class PushCommonCallback : Java.Lang.Object, Com.Alibaba.Sdk.Android.Push.ICommonCallback
    {

        public void OnFailed(string errorCode, string errorMessage)
        {
            Console.WriteLine("init cloudchannel failed -- errorcode:" + errorCode + " -- errorMessage:" + errorMessage);
        }

        public void OnSuccess(string p0)
        {
            Console.WriteLine("init cloudchannel success");

        }
    }
}
