﻿using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Contextos;
using Produtos.Infra.Data.Interfaces.Repository.Api;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Produtos.Infra.Data.Repositorios.Api
{
    public class ProdutoRepositorio : IProdutoRepository
    {
        private readonly ContextoPrincipal _contexto;

        public ProdutoRepositorio(ContextoPrincipal contexto)
        {
            _contexto = contexto;
        }

        void IProdutoRepository.Inserir(Produto entidade)
        {
            _contexto.Add(entidade);
            _contexto.SaveChanges();
        }

        void IProdutoRepository.Atualizar(Produto entidade)
        {
            _contexto.Update(entidade);
            _contexto.SaveChanges();
        }

        IQueryable<Produto> IProdutoRepository.Listar()
        {
            return _contexto.Produto
                .Include(x => x.Fornecedor)
                .AsNoTrackingWithIdentityResolution()
                .OrderBy(x => x.Nome);
        }

        bool IProdutoRepository.Existe(Expression<Func<Produto, bool>> expression)
        {
            return _contexto.Produto.Any(expression);
        }
    }
}
