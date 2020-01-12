using System.Windows.Input;
using static SAME70_CLIENT.Values.Same70Defines;
using SAME70_CLIENT.Model;

namespace SAME70_CLIENT.ViewModel
{
    public class Same70ViewModel : BaseViewModel
    {
        private Same70Model _same70Model;

        private bool _outputD0;
        private bool _outputD1;
        private bool _outputD2;
        private bool _outputD3;
        private bool _outputD4;
        private bool _outputD5;
        private bool _outputD6;
        private bool _outputD7;

        private bool _inputD14;
        private bool _inputD15;
        private bool _inputD16;
        private bool _inputD17;
        private bool _inputD18;
        private bool _inputD19;
        private bool _inputD52;
        private bool _inputD53;

        public bool OutputD0
        {
            get { return _outputD0; }
            set { SetValueAndRaisePropertyChanged(ref _outputD0, value); }
        }

        public bool OutputD1
        {
            get { return _outputD1; }
            set { SetValueAndRaisePropertyChanged(ref _outputD1, value); }
        }

        public bool OutputD2
        {
            get { return _outputD2; }
            set { SetValueAndRaisePropertyChanged(ref _outputD2, value); }
        }

        public bool OutputD3
        {
            get { return _outputD3; }
            set { SetValueAndRaisePropertyChanged(ref _outputD3, value); }
        }

        public bool OutputD4
        {
            get { return _outputD4; }
            set { SetValueAndRaisePropertyChanged(ref _outputD4, value); }
        }

        public bool OutputD5
        {
            get { return _outputD5; }
            set { SetValueAndRaisePropertyChanged(ref _outputD5, value); }
        }

        public bool OutputD6
        {
            get { return _outputD6; }
            set { SetValueAndRaisePropertyChanged(ref _outputD6, value); }
        }

        public bool OutputD7
        {
            get { return _outputD7; }
            set { SetValueAndRaisePropertyChanged(ref _outputD7, value); }
        }

        public bool InputD14
        {
            get { return _inputD14; }
            set { SetValueAndRaisePropertyChanged(ref _inputD14, value); }
        }

        public bool InputD15
        {
            get { return _inputD15; }
            set { SetValueAndRaisePropertyChanged(ref _inputD15, value); }
        }

        public bool InputD16
        {
            get { return _inputD16; }
            set { SetValueAndRaisePropertyChanged(ref _inputD16, value); }
        }

        public bool InputD17
        {
            get { return _inputD17; }
            set { SetValueAndRaisePropertyChanged(ref _inputD17, value); }
        }

        public bool InputD18
        {
            get { return _inputD18; }
            set { SetValueAndRaisePropertyChanged(ref _inputD18, value); }
        }

        public bool InputD19
        {
            get { return _inputD19; }
            set { SetValueAndRaisePropertyChanged(ref _inputD19, value); }
        }

        public bool InputD52
        {
            get { return _inputD52; }
            set { SetValueAndRaisePropertyChanged(ref _inputD52, value); }
        }

        public bool InputD53
        {
            get { return _inputD53; }
            set { SetValueAndRaisePropertyChanged(ref _inputD53, value); }
        }

        public ICommand ToggleOutputD0RelayCommand { get; set; }
        public ICommand ToggleOutputD1RelayCommand { get; set; }
        public ICommand ToggleOutputD2RelayCommand { get; set; }
        public ICommand ToggleOutputD3RelayCommand { get; set; }
        public ICommand ToggleOutputD4RelayCommand { get; set; }
        public ICommand ToggleOutputD5RelayCommand { get; set; }
        public ICommand ToggleOutputD6RelayCommand { get; set; }
        public ICommand ToggleOutputD7RelayCommand { get; set; }

        public Same70ViewModel(Same70Model model)
        {
            _same70Model = model;

            //set actions to take when button is pressed
            ToggleOutputD0RelayCommand = new RelayCommand(o => ToggleOutput(OUTPUT_D0_MASK));
            ToggleOutputD1RelayCommand = new RelayCommand(o => ToggleOutput(OUTPUT_D1_MASK));
            ToggleOutputD2RelayCommand = new RelayCommand(o => ToggleOutput(OUTPUT_D2_MASK));
            ToggleOutputD3RelayCommand = new RelayCommand(o => ToggleOutput(OUTPUT_D3_MASK));
            ToggleOutputD4RelayCommand = new RelayCommand(o => ToggleOutput(OUTPUT_D4_MASK));
            ToggleOutputD5RelayCommand = new RelayCommand(o => ToggleOutput(OUTPUT_D5_MASK));
            ToggleOutputD6RelayCommand = new RelayCommand(o => ToggleOutput(OUTPUT_D6_MASK));
            ToggleOutputD7RelayCommand = new RelayCommand(o => ToggleOutput(OUTPUT_D7_MASK));

            Update();
        }

        /* Updates the state of IO's in View */
        public void Update()
        {
            OutputD0 = _same70Model.OutputD0;
            OutputD1 = _same70Model.OutputD1;
            OutputD2 = _same70Model.OutputD2;
            OutputD3 = _same70Model.OutputD3;
            OutputD4 = _same70Model.OutputD4;
            OutputD5 = _same70Model.OutputD5;
            OutputD6 = _same70Model.OutputD6;
            OutputD7 = _same70Model.OutputD7;

            InputD14 = _same70Model.InputD14;
            InputD15 = _same70Model.InputD15;
            InputD16 = _same70Model.InputD16;
            InputD17 = _same70Model.InputD17;
            InputD18 = _same70Model.InputD18;
            InputD19 = _same70Model.InputD19;
            InputD52 = _same70Model.InputD52;
            InputD53 = _same70Model.InputD53;
        }

        /*
         * Toggles outputs on SAME70 board
         * <param name="outputMask">State to set outputs to</param>
         * 
         * <usage>
         * There are 8 outputs, each one represented by one bit in outputMask
         * 00000000
         * D7 <- D0
         * 
         * Setting bit to 1 turns the output on
         * Setting bit to 0 turns the output off
         * 
         * example:
         * ToggleOutput(5);
         * Binary representation of 5 is 00000101
         * This will turn on OutputD0 and OutputD2
         * </usage>
         */
        public void ToggleOutput(byte outputMask)
        {
            _same70Model.ToggleOutput(outputMask);
        }
    }
}
