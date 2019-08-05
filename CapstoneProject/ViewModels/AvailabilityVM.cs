using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapstoneProject.Models;

namespace CapstoneProject.ViewModels
{
    public class AvailabilityVM
    {
        public Client ClientVm { get; set; }
        public AvailableSlot AvailableSlotVm { get; set; }
    }
}