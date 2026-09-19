using Godot;
public partial class ScoreSystem : CanvasLayer {
    [Export] AnimatedSprite2D animatedGem1;
    [Export] AnimatedSprite2D animatedGem2;
    [Export] Label Label1;
    [Export] Label Label2;
    public override void _Ready() {
        animatedGem1.Play("default");
        animatedGem2.Play("default");
    }
    public override void _Process(double delta){
        Label1.Text = GlobalData.Score1 + "";
        Label2.Text = GlobalData.Score2 + "";
    }
}