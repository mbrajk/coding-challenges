## Find minimum value in sorted rotated array

Solution Language: C#

Given a sorted, rotated array we want to find the minimum value in the array in `O(log n)` time.

To rotate an array `1` time is to take an array of length `n` and move all of the elements one space to the right, while moving the final element to the beginning of the array.

Shown another way `1` rotation can be represented as:
`[i[0], i[1], i[2], i[3], ..., i[n - 1]]` becomes `[i[n - 1], i[0], i[1], i[2], ..., i[n - 2]]`

Examples: 

`[0, 1, 2, 3, 4]` rotated 1 time would become `[4, 0, 1, 2, 3]`

`[0, 1, 2, 3, 4]` rotated 2 times would become `[3, 4, 0, 1, 2]`

`[0, 1, 2, 3, 4]` rotated 3 times would become `[2, 3, 4, 0, 1]`



A slightly modified binary search is used to solve this problem

