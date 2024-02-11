
using AYDSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.ResponseModels
{
    public class BaseFooterRateResponse
    {
        public VoteType VoteType { get; set; }
    }

    public class BaseFooterFavoritedResponse
    {
        public bool IsFavorited { get; set; }

        public int FavoritedCount { get; set; }
    }

    public class BaseFooterRateFavoritedResponse : BaseFooterFavoritedResponse
    {
        public VoteType VoteType { get; set; }
    }
}
