﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OOECAPI.Data;
using System;

namespace OOECAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20181025123155_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OOECAPI.Models.GamePlayerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LobbyId");

                    b.Property<int?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("LobbyId");

                    b.HasIndex("PlayerId");

                    b.ToTable("gamePlayerInfo");
                });

            modelBuilder.Entity("OOECAPI.Models.Lobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DateStart");

                    b.Property<int>("ScoreLoser");

                    b.Property<int>("ScoreWinner");

                    b.Property<int?>("TournamentId");

                    b.Property<string>("Winner");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Lobbies");
                });

            modelBuilder.Entity("OOECAPI.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("OOECAPI.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfPlayers");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("OOECAPI.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Place");

                    b.Property<string>("PrizePool");

                    b.Property<string>("TournamentName");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("OOECAPI.Models.GamePlayerInfo", b =>
                {
                    b.HasOne("OOECAPI.Models.Lobby")
                        .WithMany("gamePlayerInfo")
                        .HasForeignKey("LobbyId");

                    b.HasOne("OOECAPI.Models.Player")
                        .WithMany("gamePlayerInfo")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("OOECAPI.Models.Lobby", b =>
                {
                    b.HasOne("OOECAPI.Models.Tournament", "Tournament")
                        .WithMany("Lobbies")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("OOECAPI.Models.Player", b =>
                {
                    b.HasOne("OOECAPI.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
