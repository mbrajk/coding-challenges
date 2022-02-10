//
// //Console.WriteLine("Starting coding interview");
//
// var ints = new List<int>
// {
//     3, 1, 2, 3, 2, 1, 1
// };
//
// var k = 2;
//
// for (int i = 0; i < ints.Count; i++)
// {
//     var allLess = true;
//     if (ints[i] < k)
//     {
//         continue;
//     }
//     
//     for (int j = i + 1; j < ints.Count; j++)
//     {
//         if (ints[j] < k || ints[j] < ints[i])
//         {
//             allLess = false;
//             (ints[i], ints[j]) = (ints[j], ints[i]);
//         }
//     }
//
//     if (allLess)
//     {
//         break;
//     }
// }
//
//
// Console.ReadKey();