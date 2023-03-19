using FluentAssertions;
using NUnit.Framework;

namespace Leet
{
    public static class ProductOfArrayExceptSelf
    {
        public static int[] FindProduct(int[] nums)
        {
            // container arrays
            var left = new int[nums.Length];
            var right = new int[nums.Length];

            // output array
            var output = new int[nums.Length];

            // left[i] contains product of all elements to the left
            left[0] = 1;

            for (var i = 1; i < nums.Length; i++)
            {
                left[i] = left[i - 1] * nums[i - 1];
            }

            // right[i] contains product of all elements to the right
            right[nums.Length - 1] = 1;

            for (var i = nums.Length - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] * nums[i + 1];
            }

            // construct output
            for (var i = 0; i < nums.Length; i++)
            {
                output[i] = left[i] * right[i];
            }

            return output;
        }
    }

    public class ProductOfArrayExceptSelfTests

    {
        [Test]
        public void ProductOfArrayExceptSelf_FindProduct_Success()
        {
            // arrange
            int[] nums = {1, 2, 3, 4};

            // act
            var ouput = ProductOfArrayExceptSelf.FindProduct(nums);

            // assert
            ouput.Should().Equal(new int[] {24, 12, 8, 6});
        }
    }
}