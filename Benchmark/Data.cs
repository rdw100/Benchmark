using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public enum DataTypes
    {
        Char1,
        Bit64,
        Bit256
    }

    public static class Data
    {
        public static String[] GetData(DataTypes dt)
        {
            String[] dataArray;   
            
            dataArray = dt switch
            {
                DataTypes.Char1 => new String[] { "a", "b", "c", "d", "e" },
                DataTypes.Bit64 => new String[] {
                        "217A25432A462D4A",
                        "743677397A244326",
                        "5971337436763979",
                        "67566B5970337336",
                        "4E645267556B5870"
                    },
                DataTypes.Bit256 => new String[] {
                        "5266556A586E3272357538782F413F442A472D4B6150645367566B5970337336",
                        "404D635166546A576E5A7234753778214125432A462D4A614E645267556B5870",
                        "4528482B4D6251655468576D5A7134743777217A25432646294A404E63526655",
                        "2F413F4428472B4B6250655368566D597133743677397A244326452948404D63",
                        "7538782F4125442A472D4B6150645367566B5970337336763979244226452848"
                    },
                _ => new String[] { "a", "b", "c", "d", "e" },
            };

            return dataArray;
        }
    }
}
