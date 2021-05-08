//-----------------------------------------------------------------------
// <copyright file=App.xaml.cs company="纳米维景">
// 版权所有 (C)2020,纳米维景(上海)医疗科技有限公司
// </copyright>
// ---------------------------------------------------------------------
// <summary>
//  修改日期                         版本号       		创建人     
// 2020/9/10           	      		V0.0.1        	   zyp     
// </summary>
// ---------------------------------------------------------------------
// <key>
// 
// </key>
//-----------------------------------------------------------------------

namespace CTCommunication
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    /// App.xaml 的交互逻辑.
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        /// <summary>
        /// Defines the _log.
        /// </summary>
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ProgramStarted.
        /// </summary>
        public EventWaitHandle ProgramStarted { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The OnStartup.
        /// </summary>
        /// <param name="e">The e<see cref="StartupEventArgs"/>.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            bool createNew;
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "CTCommunication", out createNew);
            if (!createNew)
            {
                MessageBox.Show("软件正在运行中，请不要重复启动！", "警告");
                App.Current.Shutdown();
                Environment.Exit(0);
            }
            base.OnStartup(e);
            //注册Application_Error
            //   this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);

            //  CheckAdministrator();

            Current.DispatcherUnhandledException += App_OnDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        /// <summary>
        /// The App_DispatcherUnhandledException.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="System.Windows.Threading.DispatcherUnhandledExceptionEventArgs"/>.</param>
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            _log.Info("进行全局异常处理!");
            MessageBox.Show("出现错误,需要重新启动软件!", "警告!");
            //处理完后，我们需要将Handler=true表示已此异常已处理过
            e.Handled = true;
        }

        /// <summary>
        /// UI线程抛出全局异常事件处理.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                e.Handled = true;
                _log.Info("不可恢复的UI线程全局异常" + e.Exception);
                //MessageBox.Show("UI线程全局异常" + e.Exception, "请重启!");
                //LogHelper.Instance.Logger.Error(e.Exception, "UI线程全局异常");
                //e.Handled = true;
            }
            catch (Exception ex)
            {
                _log.Info("不可恢复的UI线程全局异常" + ex);
                MessageBox.Show("UI线程全局异常" + ex.Message, "请重启!");
            }
        }

        /// <summary>
        /// The Application_Startup.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="StartupEventArgs"/>.</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
        }

        /// <summary>
        /// 检测是否以管理员身份运行.
        /// </summary>
        private void CheckAdministrator()
        {
            var wi = System.Security.Principal.WindowsIdentity.GetCurrent();
            var wp = new System.Security.Principal.WindowsPrincipal(wi);

            bool runAsAdmin = wp.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);

            if (!runAsAdmin)
            {
                var processInfo = new ProcessStartInfo(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("程序自动以管理员身份运行出错，请手动设置以管理员身份运行程序" + ex);
                    throw;
                }
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 非UI线程抛出全局异常事件处理.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                //e.Handled = true;
                var exception = e.ExceptionObject as Exception;
                if (exception != null)
                {
                    _log.Info("非UI线程全局异常" + exception.Message);
                    MessageBox.Show("非UI线程全局异常" + exception.Message, "请重启!");
                }
            }
            catch (Exception ex)
            {
                _log.Info("不可恢复的非UI线程全局异常" + ex);
                MessageBox.Show("非UI线程全局异常" + ex.Message, "请重启!");
            }
        }

        #endregion
    }
}
