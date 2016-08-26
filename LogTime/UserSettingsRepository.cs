using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace LogTime
{
    public interface IUserSettingsRepository
    {
        DateTime? TimeIn { get; set; }
    }

    class UserSettingsRepository : IUserSettingsRepository
    {
        private ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        public UserSettingsRepository()
        {
        }

        public DateTime? TimeIn
        {
            get
            {
                try
                {
                    long timeInTicks = (long)_localSettings.Values["TimeIn"];
                    return new DateTime( timeInTicks );
                }
                catch( System.NullReferenceException )
                {
                    return null;
                }
            }

            set
            {
                try
                {
                    _localSettings.Values["TimeIn"] = value.Value.Ticks;
                }
                catch( Exception )
                {

                    throw;
                }
                
            }
        }
    }
}
