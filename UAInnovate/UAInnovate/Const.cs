using System;
namespace UAInnovate
{
	public class Const
	{
        public static class Role
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
        public static class Policy
        {
            public const string AdminAndManager = "AdminAndManagerPolicy";
            public const string AdminOrManager = "AdminOrManagerPolicy";
        }
    }
}

