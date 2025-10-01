using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
          

            builder.ToTable("Jogo","Jogo");

            builder.HasKey(j => j.Guid);
            builder.Property(j => j.Guid).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(j => j.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(j => j.CriadoPor).HasColumnType("NVARCHAR(100)").IsRequired().HasMaxLength(100);
            builder.Property(j => j.ModificadoPor).HasColumnType("NVARCHAR(100)").HasMaxLength(100);
            builder.Property(j => j.DataModificacao).HasColumnType("DATETIME");
            builder.Property(j => j.Status).HasColumnType("INT").IsRequired();



            builder.Property(e => e.Nome).HasColumnType("nvarchar(200)").IsRequired().HasMaxLength(200);

            builder.Property(e => e.Genero).HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);

            builder.Property(e => e.Desenvolvedor).HasColumnType("nvarchar(200)").IsRequired().HasMaxLength(200);

            builder.Property(e => e.DataLancamento).HasColumnType("date").IsRequired();

            builder.Property(e => e.Descricao).HasColumnType("nvarchar(2000)").IsRequired();

            builder.Property(e => e.ClassificacaoIndicativa).HasColumnType("nvarchar(100)").HasMaxLength(100);

            builder.Property(e => e.Preco).HasColumnType("decimal(10,2)").IsRequired();
        }
    }
}
