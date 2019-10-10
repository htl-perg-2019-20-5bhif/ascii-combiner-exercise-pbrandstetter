using System;
using System.Collections.Generic;

namespace AsciiCombiner
{
    public class Logic
    {
        public string Merge(List<string> content)
        {
            char[] merged = content[0].ToCharArray();
            for (int i = 0; i < content.Count; i++)
            {
                for (int j = 0; j < content[i].Length; j++)
                {
                    if(merged[j].Equals(' ')) {
                        merged[j] = content[i].ToCharArray()[j];
                    }
                }
            }
            return new string(merged);
        }
    }
}
