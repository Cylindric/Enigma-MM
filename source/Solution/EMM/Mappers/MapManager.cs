﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnigmaMM
{
    static class MapManager
    {
        static private Dictionary<string, Mapper> Mappers = new Dictionary<string, Mapper>();
        
        static public void Register(string tag, Mapper mapper)
        {
            Mappers.Add(tag, mapper);
        }

        static public void RenderMaps(string[] args)
        {
            string tag = "all";
            string type = "main";

            if (args.Length > 1)
            {
                tag = args[1];
            }
            if (args.Length > 2)
            {
                type = args[2];
            }
            if (tag == "all")
            {
                foreach (Mapper mapper in Mappers.Values)
                {
                    mapper.Render(type);
                }
            }
            else
            {
                if (Mappers.ContainsKey(tag))
                {
                    Mappers[tag].Render(type);
                }
            }
        }
    }
}