﻿namespace Life.Game;

public static class LifeShapes {
  #region Stiff lifes

  public const string Block = """
                              ....
                              .**.
                              .**.
                              ....
                              """;

  public const string BeeHive = """
                                ......
                                ..**..
                                .*..*.
                                ..**..
                                ......
                                """;

  public const string Loaf = """
                             ......
                             ..**..
                             .*..*.
                             ..*.*.
                             ...*..
                             ......
                             """;

  public const string Boat = """
                             .....
                             .**..
                             .*.*.
                             ..*..
                             """;

  public const string Tub = """
                            .....
                            ..*..
                            .*.*.
                            ..*..
                            """;

  #endregion

  #region Oscillators

  public const string Blinker = """
                                .....
                                ..*..
                                ..*..
                                ..*..
                                .....
                                """;

  public const string Toad = """
                             ......
                             ......
                             ..***.
                             .***..
                             ......
                             ......
                             """;

  public const string Beacon = """
                               ......
                               .**...
                               .**...
                               ...**.
                               ...**.
                               """;

  #endregion
}