using System;
using System.Windows.Threading;

namespace MyClock
{
    //時計モデル
    public class Clock
    {
        //一定時間ごとに起こるイベント
        public event EventHandler<DateTime> Tick;

        //タイマー（Startすると100msごとにTickイベントを起こす）
        DispatcherTimer timer 
            = new DispatcherTimer{ Interval = TimeSpan.FromMilliseconds(100) };

        public Clock()
        {
            //タイマーのTickイベントにイベントハンドラを登録
            timer.Tick += (sender, e) => {
                //もしこのClockのTickイベントにイベントハンドラが登録されていたら
                if (Tick != null)
                    //イベントハンドラを渡して現在時刻を渡す
                    Tick(sender: this, e: DateTime.Now);
            };
            //タイマーを開始
            timer.Start();
        }

    }
}
