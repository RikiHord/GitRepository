# FoxholeWatcher

**FoxholeWatcher** Ч .NET сервис дл€ мониторинга карт Foxhole и отправки обновлений в Discord.

## —труктура проекта

- `Foxhole/` Ч API клиент Foxhole + модели данных
- `Discord/` Ч клиент дл€ Webhook Discord
- `Tasks/` Ч задачи (Tasks) дл€ инициализации и мониторинга карт
- `Program.cs` Ч точка входа, конфигураци€ DI и запуск приложени€

## Ќастройка

1. —копируйте `appsettings.example.json` в `appsettings.json`
2. ”кажите URL Discord Webhook:

```json
{
  "DiscordWebhookUrl": "YOUR_WEBHOOK_URL_HERE",
}