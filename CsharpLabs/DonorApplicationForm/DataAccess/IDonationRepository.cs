﻿using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DataAccess
{
    interface IDonationRepository
    {
        List<DonationRecord> GetDonorRecords(Guid personId);
        void Add(Guid personId, DonationRecord record);
        void Remove(Guid personId, DateTime at);
    }

}
