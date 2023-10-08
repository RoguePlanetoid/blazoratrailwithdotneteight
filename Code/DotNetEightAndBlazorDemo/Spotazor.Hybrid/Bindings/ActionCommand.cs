namespace Spotazor.Hybrid.Bindings;

/// <summary>
/// Action Command
/// </summary>
/// <param name="action">Action</param>
public class ActionCommand(Action<object?> action) : ActionCommandObservableBase(
    new ActionCommandHandler((param) =>
        action(param), (param) =>
            (param as ActionCommand)?.IsEnabled ?? true));
