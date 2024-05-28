using CommunityToolkit.Mvvm.ComponentModel;
using PedraPapelETesoura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PedraPapelETesoura.ViewModels
{
    public partial class JokenPoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private Jogador _jogador;

        [ObservableProperty]
        private Jogador _maquina;
        
        [ObservableProperty]
        private Opcao _escolha;

        [ObservableProperty]
        private string _result;

        [ObservableProperty]
        private string _enemyImage;

        [ObservableProperty]
        private string _playerImage;

        [ObservableProperty]
        private int _pontuacao;

        public ICommand MakeChoiceCommand { get; }

        public JokenPoViewModel()
        {
            Jogador = new Jogador(Name);
            Maquina = new Jogador("Máquina");
            MakeChoiceCommand = new Command(MakeChoice);
        }

        private void MakeChoice()
        {
            Jogador.Nome = Name;
            Jogador.Escolha = Escolha;
            Maquina.Escolha = (Opcao)new Random().Next(0, 3);
            EnemyImage = $"{Maquina.Escolha}.png";
            PlayerImage = $"{Jogador.Escolha}.png";
            DetermineWinner();
            Pontuacao = Jogador.Pontuacao;
        }

        private void DetermineWinner()
        {
            if (Jogador.Escolha == Maquina.Escolha)
            {
                Jogador.Pontuacao++;
                Maquina.Pontuacao++;
                Result = "Empate!";
            }
            else if ((Jogador.Escolha == Opcao.PEDRA && Maquina.Escolha == Opcao.TESOURA) ||
                     (Jogador.Escolha == Opcao.PAPEL && Maquina.Escolha == Opcao.PEDRA) ||
                     (Jogador.Escolha == Opcao.TESOURA && Maquina.Escolha == Opcao.PAPEL))
            {
                Jogador.Pontuacao += 3;
                Result = $"{Jogador.Nome} Venceu!";
            }
            else
            {
                Maquina.Pontuacao++;
                Result = $"{Maquina.Nome} Venceu!";
            }

            //OnPropertyChanged(nameof(Jogador));
            //OnPropertyChanged(nameof(Maquina));
        }
    }
}

