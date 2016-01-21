using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtifitialUnintteligence_proto
{
    public class Responder
    {
        public Responder(string name)
        {
            Name = name;
        }

        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public virtual string Response(string input)
        {
            return "";
        }
        /*
        private string input;
        public string Input
        {
            private set; get;
        }
        */
    }

    class WhatResponder : Responder
    {
        
        public WhatResponder(string name) : base(name)
        {
            Name = name;
        }

        public override string Response(string input)
        {
            return input + "って何?";
        }
    }

    class RandomResponder : Responder
    {
        private string[] responses = { "今日は寒い", "チョコ食べたい", "昨日、10円拾った" };

        
        public RandomResponder(string name) : base(name)
        {
            Name = name;
        }

        public override string Response(string input)
        {
            Random rand = new Random();
            return responses[rand.Next(responses.Length)];
        }
    }
}
