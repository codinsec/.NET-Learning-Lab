// Async Programming Examples

// 1. Basic Async/Await
Console.WriteLine("=== Basic Async/Await ===");
await BasicAsyncExample();
Console.WriteLine();

// 2. Async Method with Return Value
Console.WriteLine("=== Async with Return Value ===");
int result = await GetNumberAsync();
Console.WriteLine($"Result: {result}");
Console.WriteLine();

// 3. Multiple Async Operations
Console.WriteLine("=== Multiple Async Operations ===");
await MultipleAsyncOperations();
Console.WriteLine();

// 4. Parallel Execution
Console.WriteLine("=== Parallel Execution ===");
await ParallelExecution();
Console.WriteLine();

// 5. Exception Handling in Async
Console.WriteLine("=== Exception Handling ===");
await AsyncExceptionHandling();
Console.WriteLine();

// 6. Cancellation Token
Console.WriteLine("=== Cancellation Token ===");
await CancellationExample();
Console.WriteLine();

// 7. Task.Run for CPU-bound Work
Console.WriteLine("=== Task.Run ===");
await TaskRunExample();
Console.WriteLine();

// Async Method Definitions

static async Task BasicAsyncExample()
{
    Console.WriteLine("Starting async operation...");
    await Task.Delay(1000); // Simulate async work
    Console.WriteLine("Async operation completed!");
}

static async Task<int> GetNumberAsync()
{
    Console.WriteLine("Fetching number asynchronously...");
    await Task.Delay(500);
    return 42;
}

static async Task MultipleAsyncOperations()
{
    Console.WriteLine("Starting multiple operations...");
    
    var task1 = SimulateWorkAsync("Task 1", 1000);
    var task2 = SimulateWorkAsync("Task 2", 1500);
    var task3 = SimulateWorkAsync("Task 3", 800);
    
    await Task.WhenAll(task1, task2, task3);
    Console.WriteLine("All operations completed!");
}

static async Task ParallelExecution()
{
    Console.WriteLine("Starting parallel execution...");
    
    var tasks = new List<Task<string>>
    {
        SimulateWorkWithResultAsync("Operation A", 1000),
        SimulateWorkWithResultAsync("Operation B", 1200),
        SimulateWorkWithResultAsync("Operation C", 800)
    };
    
    var results = await Task.WhenAll(tasks);
    
    Console.WriteLine("Results:");
    foreach (var result in results)
    {
        Console.WriteLine($"  {result}");
    }
}

static async Task AsyncExceptionHandling()
{
    try
    {
        await SimulateErrorAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Caught exception: {ex.Message}");
    }
}

static async Task CancellationExample()
{
    using var cts = new CancellationTokenSource();
    
    // Cancel after 2 seconds
    cts.CancelAfter(2000);
    
    try
    {
        await LongRunningOperationAsync(cts.Token);
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Operation was cancelled");
    }
}

static async Task TaskRunExample()
{
    Console.WriteLine("Starting CPU-bound work on background thread...");
    
    var result = await Task.Run(() =>
    {
        // Simulate CPU-intensive work
        int sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            sum += i;
        }
        return sum;
    });
    
    Console.WriteLine($"CPU-bound work completed. Result: {result:N0}");
}

// Helper Async Methods

static async Task SimulateWorkAsync(string taskName, int delayMs)
{
    Console.WriteLine($"{taskName} started");
    await Task.Delay(delayMs);
    Console.WriteLine($"{taskName} completed");
}

static async Task<string> SimulateWorkWithResultAsync(string operationName, int delayMs)
{
    await Task.Delay(delayMs);
    return $"{operationName} finished in {delayMs}ms";
}

static async Task SimulateErrorAsync()
{
    await Task.Delay(500);
    throw new InvalidOperationException("Simulated error in async operation");
}

static async Task LongRunningOperationAsync(CancellationToken cancellationToken)
{
    for (int i = 0; i < 10; i++)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Console.WriteLine($"Working... {i + 1}/10");
        await Task.Delay(500, cancellationToken);
    }
    Console.WriteLine("Long running operation completed!");
}
