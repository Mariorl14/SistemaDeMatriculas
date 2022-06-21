using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Entities
{
    public partial class SISTEMA_ACADEMICOContext : DbContext
    {
        public SISTEMA_ACADEMICOContext()
        {
        }

        public SISTEMA_ACADEMICOContext(DbContextOptions<SISTEMA_ACADEMICOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<PlanEstudio> PlanEstudios { get; set; } = null!;
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQL5109.site4now.net,1433;Database=db_a88d1d_sistmat;Integrated Security=False;User ID=db_a88d1d_sistmat_admin;Password=SistMat1234..;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__CURSO__9B4AE7986ACB66CF");

                entity.ToTable("CURSO");

                entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");

                entity.Property(e => e.CodigoCurso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_CURSO");

                entity.Property(e => e.Creditos).HasColumnName("CREDITOS");

                entity.Property(e => e.Duracion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DURACION");

                entity.Property(e => e.Horario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HORARIO");

                entity.Property(e => e.IdPlanEstudioFk).HasColumnName("ID_PLAN_ESTUDIO_FK");

                entity.Property(e => e.NaturalezaCurso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NATURALEZA_CURSO");

                entity.Property(e => e.NombreCurso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CURSO");

                entity.Property(e => e.Precio).HasColumnName("PRECIO");

                entity.HasOne(d => d.IdPlanEstudioFkNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdPlanEstudioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSO__ID_PLAN_E__267ABA7A");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__ESTUDIAN__5598088036A6CE5D");

                entity.ToTable("ESTUDIANTE");

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_NACIMIENTO");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENERO")
                    .IsFixedLength();

                entity.Property(e => e.IdPlanEstudioFk).HasColumnName("ID_PLAN_ESTUDIO_FK");

                entity.Property(e => e.IdTipoUsuarioFk).HasColumnName("ID_TIPO_USUARIO_FK");

                entity.Property(e => e.IdUsuarioFk).HasColumnName("ID_USUARIO_FK");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRIMER_APELLIDO");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDO_APELLIDO");

                entity.HasOne(d => d.IdPlanEstudioFkNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdPlanEstudioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTUDIANT__ID_PL__2F10007B");

                entity.HasOne(d => d.IdTipoUsuarioFkNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdTipoUsuarioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTUDIANT__ID_TI__300424B4");

                entity.HasOne(d => d.IdUsuarioFkNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdUsuarioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ESTUDIANT__ID_US__2E1BDC42");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PK__MATRICUL__09B08780303982ED");

                entity.ToTable("MATRICULA");

                entity.Property(e => e.IdMatricula).HasColumnName("ID_MATRICULA");

                entity.Property(e => e.FechaMatricula)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_MATRICULA");

                entity.Property(e => e.IdCursoFk).HasColumnName("ID_CURSO_FK");

                entity.Property(e => e.IdEstudianteFk).HasColumnName("ID_ESTUDIANTE_FK");

                entity.Property(e => e.IdPlanEstudioFk).HasColumnName("ID_PLAN_ESTUDIO_FK");

                entity.HasOne(d => d.IdCursoFkNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdCursoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MATRICULA__ID_CU__34C8D9D1");

                entity.HasOne(d => d.IdEstudianteFkNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdEstudianteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MATRICULA__ID_ES__32E0915F");

                entity.HasOne(d => d.IdPlanEstudioFkNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdPlanEstudioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MATRICULA__ID_PL__33D4B598");
            });

            modelBuilder.Entity<PlanEstudio>(entity =>
            {
                entity.HasKey(e => e.IdPlanEstudio)
                    .HasName("PK__PLAN_EST__680979317DA2985E");

                entity.ToTable("PLAN_ESTUDIO");

                entity.Property(e => e.IdPlanEstudio).HasColumnName("ID_PLAN_ESTUDIO");

                entity.Property(e => e.NombrePlanEstduio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_PLAN_ESTDUIO");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPO_USU__85A05968E5C690B5");

                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__91136B906697E81C");

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.ConfirmarContrasena).HasColumnName("CONFIRMAR_CONTRASENA");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IdTipoUsuarioFk).HasColumnName("ID_TIPO_USUARIO_FK");

                entity.Property(e => e.Telefono).HasColumnName("TELEFONO");

                entity.HasOne(d => d.IdTipoUsuarioFkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuarioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__ID_TIPO__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
