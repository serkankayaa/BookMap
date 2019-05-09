using System.ComponentModel;

namespace BookStore.Business.Helpers
{
    public static class EnumHelpers
    {
        public static string GetDescription<T>(T item)
        {
            var descriptionAttributes = typeof(T)
                .GetMember(typeof(T)
                .GetEnumName(item))[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false)[0];

            return ((DescriptionAttribute)descriptionAttributes).Description;
        }
    }
}