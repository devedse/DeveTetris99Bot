namespace DeveTetris99Bot.Tetris.Logic
{
    public class TetrisActionWithEvaluation
    {
        public TetrisAction Action { get; }
        public EvaluationState EvaluationState { get; }

        public TetrisActionWithEvaluation(TetrisAction action, EvaluationState evaluationState)
        {
            Action = action;
            EvaluationState = evaluationState;
        }

        public override string ToString()
        {
            return $"ActionWithEvaluation(Action={Action},State={EvaluationState})";
        }
    }
}
