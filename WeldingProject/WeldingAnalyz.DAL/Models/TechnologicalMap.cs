﻿namespace WeldingAnalyz.DAL.Models
{
    public class TechnologicalMap : BaseEntity
    {
        public double VoltageMin { get; set; }
        public double VoltageMax { get; set; }
        public double AmperageMin { get; set; }
        public double AmperageMax { get; set; }
        public int? TaskId { get; set; }
        public Task Task { get; set; }
    }
}
