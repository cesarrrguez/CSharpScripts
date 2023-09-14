#load "../../../packages.csx"

using CommunityToolkit.Diagnostics;

// SubmitInfo(null, 5, null);
// System.ArgumentNullException: Parameter "array" (int[]) must be not null).

// SubmitInfo(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 5, null);
// System.ArgumentException: Parameter "array" (int[]) must have a size less than 10, had a size of <11>.

// SubmitInfo(new[] { 1, 2, 3 }, 5, null);
// System.ArgumentOutOfRangeException: Parameter "index" (int) must be in the range given by <0> and <3> to be a valid index for the target collection

// SubmitInfo(new[] { 1, 2, 3 }, 1, null);
// System.ArgumentNullException: Parameter "text" (string) must not be null or empty, was null.

SubmitInfo(new[] { 1, 2, 3 }, 1, "Hello World");

public void SubmitInfo(int[] array, int index, string text)
{
    Guard.IsNotNull(array);
    Guard.HasSizeLessThan(array, 10);
    Guard.IsInRangeFor(index, array);
    Guard.IsNotNullOrEmpty(text);
}
