using System;
using System.ComponentModel;


namespace MyClock
{
    //時計ビューモデル
    //「プロパティの更新を追加する」というインターフェースを実装
    public class ClockViewModel : INotifyPropertyChanged
    {
        //短針の角度
        double hourHandAngle = 0.0;
        //長針の角度
        double minuteHandAngle = 0.0;
        //秒針の角度
        double secondHandAngle = 0.0;


        //「プロパティが更新された」というイベント
        //INotifyPropertyChangedインターフェースの実装に必須
        public event PropertyChangedEventHandler PropertyChanged;

        //時計モデル
        Clock clock = new Clock();

        //デジタル表示文字列
        string digitalDisplay = string.Empty;

        //デジタル表示文字列プロパティ
        public string DigitalDisplay
        {
            get //取得
            {
                return digitalDisplay;
            }
            private set //クラス外から使わないのでprivate
            {
                //デジタル表示文字列が更新されたら
                if(digitalDisplay != value)
                {
                    digitalDisplay = value;
                    //イベントを呼び出して、
                    //DigitalDisplayプロパティが更新された旨を通知
                    RaisePropertyChanged("DigitalDisplay");
                }
            }
         }

        //コンストラクタ
        public ClockViewModel()
        {
            //clockのTickイベントにイベントハンドラを登録:
            //clockから現在時刻が通知されるたびに
            clock.Tick += (sender, currentTime) => {
                //デジタル表示文字列を更新
                DigitalDisplay = currentTime.ToLongTimeString();
                //針の角度を更新
                UpdateHandAngles(currentTime);
            };
        }


        void RaisePropertyChanged(String PropertyName)
        {
            //PropertyChangedイベントにイベントハンドラが登録されていたら
            if (PropertyChanged != null)
                //イベントハンドラを呼び出して
                //propertyNameに当たるプロパティが更新された旨を通知
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        //短針の角度プロパティ
        public double HourHandAngle
        {
            get //取得
            {
                return hourHandAngle;
            } 
            private set //設定（クラス外から使わないのでprivate）
            {
                //短針の角度が更新されたら
                if (hourHandAngle != value)
                {
                    hourHandAngle = value;
                    //イベントハンドラを呼び出して、
                    //HourHandAngleプロパティが更新されて旨を通知
                    RaisePropertyChanged("HourHandAngle");
                }
            }
        }
        
        //長針の角度プロパティ
        public double MinuteHandAngle
        {
            get //取得
            {
                return minuteHandAngle;
            }
            private set //設定（クラス外から使わないのでprivate）
            {
                //長針の角度が更新されたら
                if (minuteHandAngle != value)
                {
                    minuteHandAngle = value;
                    //イベントハンドラを呼び出して、
                    //MinuteHandAngleプロパティが更新されて旨を通知
                    RaisePropertyChanged("MinuteHandAngle");
                }
            }
        }

        //秒針の角度プロパティ
        public double SecondHandAngle
        {
            get //取得
            {
                return secondHandAngle;
            }
            private set //設定（クラス外から使わないのでprivate）
            {
                //短針の角度が更新されたら
                if (secondHandAngle != value)
                {
                    secondHandAngle = value;
                    //イベントハンドラを呼び出して、
                    //SecondHandAngleプロパティが更新されて旨を通知
                    RaisePropertyChanged("SecondHandAngle");
                }
            }
        }

        void UpdateHandAngles(DateTime time)
        {
            //秒針の更新
            SecondHandAngle = time.Second * 360.0 / 60.0;
            //長針の更新
            MinuteHandAngle
                = (time.Minute + time.Second / 60.0) * 360.0 / 60.0;
            //短針の更新
            HourHandAngle
                = (time.Hour + time.Minute / 60.0) * 360.0 / 12.0;
        }
    }
}
