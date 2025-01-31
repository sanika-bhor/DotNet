namespace BIApp.Models
{
    public class RevenueModel
    {
        public string Name{get;set;}
        public int revenueYear2005{get;set;}
        public int revenueYear2010{get;set;}
        public int revenueYear2015{get;set;}
        public int revenueYear2020{get;set;}
        public int revenueYear2025{get;set;}
        public RevenueModel(string name,int y2005,int y2010, int y2015,int y2020, int y2025)
        {
            this.Name=name;
            this.revenueYear2005=y2005;
            this.revenueYear2010=y2010;
            this.revenueYear2015=y2015;
            this.revenueYear2020=y2020;
            this.revenueYear2025=y2025;
        }

    }

    public class RevenueModelAccessLayer
    {
        public static List<RevenueModel> getCityRevenue()
        {
            List<RevenueModel> city =new List<RevenueModel>();
            city.Add(new RevenueModel("pune",2562,4560,4560,4564,7890));
            city.Add(new RevenueModel("nashik",4562,789,7863,9856,5478));
            city.Add(new RevenueModel("manchar",785,7563,7854,6523,963));
            city.Add(new RevenueModel("mumbai",1236,1456,3256,2145,1478));
            return city;
        }

        public static List<RevenueModel> getStateRevenue()
        {
            List<RevenueModel> state = new List<RevenueModel>();
            state.Add(new RevenueModel("india", 25621, 45620, 43560, 44564, 57890));
            state.Add(new RevenueModel("america", 45602, 7879, 78863, 99856, 56478));
            state.Add(new RevenueModel("china", 7825, 71563, 78354, 64523,5963));
            state.Add(new RevenueModel("japan", 12360,14569, 32568, 21475, 14768));
            return state;
        }
    }
}