import { Slot, component$ } from "@builder.io/qwik";
import { type DocumentHead } from "@builder.io/qwik-city";
import Header from "../components/template/header";
import Navigation from "~/components/template/navigation";
import { Hero } from "~/components/template/hero";
export default component$(() => {
  
  const isHomePage = true;
  return (
    <>      
      <div class="flex w-full flex-col">
      <Header />

      {isHomePage && <Hero />}

      <div class="relative mx-auto flex w-full max-w-8xl flex-auto justify-center sm:px-2 lg:px-8 xl:px-12">
        <div class="hidden lg:relative lg:block lg:flex-none">
          <div class="absolute inset-y-0 right-0 w-[50vw] bg-slate-50 dark:hidden" />
          <div class="absolute bottom-0 right-0 top-16 hidden h-12 w-px bg-gradient-to-t from-slate-800 dark:block" />
          <div class="absolute bottom-0 right-0 top-28 hidden w-px bg-slate-800 dark:block" />
          <div class="sticky top-[4.75rem] -ml-0.5 h-[calc(100vh-4.75rem)] w-64 overflow-y-auto overflow-x-hidden py-16 pl-0.5 pr-8 xl:w-72 xl:pr-16">
            <Navigation />
          </div>
        </div>
        <Slot />
      </div>
    </div>
    </>
  );
});

export const head: DocumentHead = {
  title: "Welcome to Qwik",
  meta: [
    {
      name: "description",
      content: "Qwik site description",
    },
  ],
};
