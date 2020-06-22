using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Specifications
{
   public class ProductSpecParams
    {
        int MaxSize = 50;
        public int PageIndex { set; get; } = 1;
        int _pageSize = 6;
        public int PageSize {
            get { return _pageSize; }
            
            set {
                if (value > MaxSize)
                {
                    _pageSize = MaxSize;
                }
                else {
                    _pageSize = value;
                }
            }
        }

        public int? BrandId { set; get; }
        public int? TypeId { set; get; }
        public string Sort { set; get; }
        private string _search { set; get; }
        public string Search {
            get {
                return _search;
            }
            set {
                _search = value.ToLower();
            }

        }
    }
}
