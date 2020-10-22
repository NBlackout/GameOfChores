namespace GameOfChores.Application.UseCases.AddChoreType
{
    public class AddChoreTypeParameter
    {
        public string Label { get; }

        public AddChoreTypeParameter(string label)
        {
            Label = label;
        }
    }
}
