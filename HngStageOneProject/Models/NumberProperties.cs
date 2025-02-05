﻿namespace HngStageOneProject.Models
{
    public class NumberProperties
    {
        public int Number { get; set; }
        public bool IsPrime { get; set; }
        public bool IsPerfect { get; set; }
        public List<string> Properties { get; set; } = new List<string>();
        public int DigitSum { get; set; }
        public string? FunFact { get; set; }
    }
}
