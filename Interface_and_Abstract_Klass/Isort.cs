using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3_Interface_and_Abstract_Klass
{
    interface ISort
    {
        void SortAsc(int[] array);

        void SortDesc(int[] array);

        void SortByParam( bool isAsc, int[] array);


    }
}
