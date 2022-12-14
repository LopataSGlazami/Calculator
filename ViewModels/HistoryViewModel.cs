using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        public ObservableCollection<String> Histories{ get; }
        
        public HistoryViewModel(Guid id)
        {
            Histories = new ObservableCollection<string>();
            var history = MainViewModel.Data.HistoryRep.Histories.Where(h => h.UserId == id);
            if (history == null || !history.Any())
                Histories.Add("pusto");
            else
            {
                foreach (var item in history) Histories.Add(item.ToString());
            }
        }
    }
}
