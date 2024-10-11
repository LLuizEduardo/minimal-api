using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;

namespace Test.Mocks;

public class VeiculosServicoMock : IVeiculoServico
{
    private static List<Veiculo> veiculos = new();

    public void Apagar(Veiculo veiculo)
    {
        veiculos.Remove(veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        var veiculoBanco = veiculos.FirstOrDefault(x => x.Id == veiculo.Id);
        if (veiculoBanco is not null)
        {
            veiculos.Remove(veiculoBanco);
            veiculos.Add(veiculo);
        }
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculo.Id = veiculos.Count + 1;
        veiculos.Add(veiculo);
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        return veiculos;
    }

    Veiculo? IVeiculoServico.BuscaPorId(int id)
    {
        return veiculos.Find(v => v.Id.Equals(id));
    }
}