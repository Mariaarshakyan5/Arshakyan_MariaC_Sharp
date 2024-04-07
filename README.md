# Sorting Algorithms Implementation

This project implements three sorting algorithms: Selection Sort, Merge Sort (partially implemented), and Shell Sort, using the Object-Oriented Template Method pattern. It also includes a console application to compare the execution speeds of these algorithms.

## Implementation Details

- **Sorting Algorithms:**
  - **Selection Sort:** Implemented in the `SelectionSorter` class, this algorithm sorts an array by repeatedly selecting the minimum element and swapping it with the element at the current position.
  - **Merge Sort:** Although partially implemented, the `MergeSorter` class contains the structure for Merge Sort adhering to the Template Method pattern.
  - **Shell Sort:** Implemented in the `ShellSorter` class, this algorithm sorts the array using a sequence of decreasing gaps for comparison and swapping.

- **Template Method Pattern:**
  - The core sorting logic is encapsulated in the `Sorter` abstract class, defining a template method `Sort()`.
  - Subclasses (`SelectionSorter`, `MergeSorter`, `ShellSorter`) override specific methods to implement their sorting strategies.

- **Execution Speed Comparison:**
  - The project includes functionality to measure the execution time of each sorting algorithm using `Stopwatch` objects.
  - After sorting, the elapsed time is printed to the console, allowing comparison of the execution speeds.

## Usage

To run the console application and compare the execution speeds of sorting algorithms:
1. Compile the project.
2. Run the compiled executable.
3. Follow the on-screen instructions to observe the execution speeds of Selection Sort and Shell Sort.




