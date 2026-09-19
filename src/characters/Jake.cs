using Godot;
public partial class Jake : CharacterBody2D {
    [Export] Movement movement;
    [Export] AnimatedSprite2D animatedSprite;
    [Export] Label CurrentAbility;
    [Export] Label Cooldown;
    private Vector2 inputVector;
    private Timer Timer;
    private Timer Timer2;
    private bool IsAbilityReady = true;
    public override void _Ready() {
        movement.Setup(this);
        InitTimer();
        InitTimer2();
    }
    public override void _Process(double delta) {
        Animation();
        if (!Timer.IsStopped()) CurrentAbility.Text = $"Rapidez: {Timer.TimeLeft:F1}";
        if (!Timer2.IsStopped()) Cooldown.Text = $"Cooldown: {Timer2.TimeLeft:F1}";
    }
    public override void _PhysicsProcess(double delta) {
        CheckInputVector();
        // Ejecutar movimiento de acuerdo al Vector.
        movement.Move(inputVector.Normalized());
    }
    private void Animation() {
        CheckInputVector();
        // Ejecutar animación de acuerdo al Vector.
        if (inputVector.Length() > 0) {
            if (inputVector.Y != 0) {
                if (inputVector.Y < 0) animatedSprite.Play("move_up");
                else if (inputVector.Y > 0) animatedSprite.Play("move_down");
            } 
            else {
                if (inputVector.X < 0) animatedSprite.Play("move_left");
                else if (inputVector.X > 0) animatedSprite.Play("move_right");
            }
        } 
        else animatedSprite.Play("stop");
    }
    void CheckInputVector() {
        // Obtener Vector de movimiento correspondiente.
        Node parent = GetParent();
        if (parent is Player1 player1) inputVector = player1.InputVector;
        else if (parent is Player2 player2) inputVector = player2.InputVector;
    }
    public void Ability() {
        if (IsAbilityReady) {
            movement.speed = 400;
            IsAbilityReady = false;
            Timer.Start();
            CurrentAbility.Visible = true;
        }
    }
    private void InitTimer() {
        Timer = new Timer();
        Timer.WaitTime = 5.0f;
        Timer.OneShot = true;
        Timer.Connect("timeout", new Callable(this, nameof(Timeout)));
        AddChild(Timer);
    }
    private void Timeout() {
        movement.speed = 200;
        CurrentAbility.Visible = false;
        Cooldown.Visible = true;
        Timer2.Start();
    }
    private void InitTimer2() {
        Timer2 = new Timer();
        Timer2.WaitTime = 20.0f;
        Timer2.OneShot = true;
        Timer2.Connect("timeout", new Callable(this, nameof(Timeout2)));
        AddChild(Timer2);
    }
    private void Timeout2() {
        IsAbilityReady = true;
        Cooldown.Visible = false;
    }
}