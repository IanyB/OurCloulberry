using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using StudentSystem.Library;
using StudentSystem.Library.Data;
using StudentSystem.Library.Models;
using StudentSystem.WpfClient.Behavior;

namespace StudentSystem.WpfClient.ViewModels
{
    public class SearchViewModel: PropertyChange, INameViewModel
    {
        private SearchResultModel _searchResult;
        public string Name { get; private set; }

        public SearchResultModel SearchResult
        {
            get { return _searchResult; }
            set
            {
                if (_searchResult != value)
                {
                    _searchResult = value;
                    RaisePropertyChanged("SearchResult");
                }
            }
        }

        public ICommand SearchCommand { get; set; } 


        public SearchViewModel()
        {
            Name = "Welcome to the search page";
            this.SearchCommand = new RelayCommand(this.ExecuteSearchCommand);
        }

        private void ExecuteSearchCommand(object parameters)
        {
            var e = parameters as KeyEventArgs;
            if (e != null && e.Key == Key.Enter)
            {
                var txtSearch = e.OriginalSource as TextBox;
                if (txtSearch != null)
                {
                    var searchQuery = txtSearch.Text;
                    LoadData.Search(searchQuery, AppCache.Config.AccessToken, model =>
                    {
                        model.Users.AddRange(model.Users);
                        model.Users.AddRange(model.Users);
                        this.SearchResult = model;
                    });
                }
            }
        }
    }
}
