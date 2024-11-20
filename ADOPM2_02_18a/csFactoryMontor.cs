using System;
namespace ADOPM3_02_18a
{
	public class csFactoryMontor
	{
		public Action<int> AlarmStatus { get; set; } = null;


        public bool CheckStatus()
		{
			//kod to check the factory floor if any machine signals an error
			//..
			bool _allOk = false;
			if (!_allOk)
			{
                //Signal an error
                AlarmStatus?.Invoke(3);
            }
			else
			{
				//All good
                AlarmStatus?.Invoke(0);
            }

			return _allOk;
		}
		public csFactoryMontor()
		{
		}
	}
}

