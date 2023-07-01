using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Player;
using ServiceLocator.Main;

namespace ServiceLocator.UI
{
    public class MonkeyCellController
    {
        private PlayerService playerService;
        private MonkeyCellView monkeyCellView;
        private MonkeyCellScriptableObject monkeyCellSO;

        public MonkeyCellController(PlayerService playerService, Transform cellContainer, MonkeyCellView monkeyCellPrefab, MonkeyCellScriptableObject monkeyCellScriptableObject)
        {
            this.playerService = playerService;
            this.monkeyCellSO = monkeyCellScriptableObject;
            monkeyCellView = Object.Instantiate(monkeyCellPrefab, cellContainer);
            monkeyCellView.SetController(this);
            monkeyCellView.ConfigureCellUI(monkeyCellSO.Sprite, monkeyCellSO.Name, monkeyCellSO.Cost);
        }

        public void MonkeyDroppedAt(Vector3 dropPosition)
        {
            playerService.TrySpawningMonkey(monkeyCellSO.Type, monkeyCellSO.Cost, dropPosition);
        }
    }
}