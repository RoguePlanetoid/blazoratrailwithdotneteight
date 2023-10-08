namespace Spotazor.Hybrid.Models;

/// <summary>
/// Content Model
/// </summary>
public class ContentModel(Action<object?> acceptAction, Action<object?> saveAction) : ObservableBase
{
    private Model _model = new();
    private bool _isLoaded = false;

    /// <summary>
    /// Accept Action
    /// </summary>
    public ActionCommand AcceptAction { get; } = new ActionCommand(acceptAction);

	/// <summary>
	/// Save Action
	/// </summary>
	public ActionCommand SaveAction { get; } = new ActionCommand(saveAction);

	/// <summary>
	/// Model
	/// </summary>
	public Model Model { get => _model; set => SetProperty(ref _model, value); }

    /// <summary>
    /// Is Loaded
    /// </summary>
    public bool IsLoaded { get => _isLoaded; set => SetProperty(ref _isLoaded, value); }
}
